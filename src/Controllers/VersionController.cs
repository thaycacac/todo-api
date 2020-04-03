using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using ToDoAPI.Entities;
using ToDoAPI.Ultil;
using System.Diagnostics;

namespace ToDoAPI.Controllers
{
    [Route("api/itauto")]
    public class VersionController : Controller
    {
        private string _connectionString;

        public VersionController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //GET api/itauto
        [HttpGet]
        public async Task<IActionResult> Get(string model)
        {
            try
            {
                VersionMasterEntities newVersion;

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = @"SELECT Top 1 * FROM CK_Version_MASTER Order By Version DESC";
                    newVersion = await connection.QuerySingleAsync<VersionMasterEntities>(query);
                }
                return Ok(new MessageAPI("S0001", newVersion, "Get new version success!!!"));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        //GET api/itauto
        [HttpGet("test")]
        public async Task<IActionResult> demo(string model)
        {
            try
            {
                return Ok(new MessageAPI("S0001", null, "Get new version success!!!"));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }


        // POST api/itauto
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] VersionDetailEntities model)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = @"INSERT INTO CK_Version_DETAILS VALUES (@version, @ipPos, @updateDate, @storeCode, @insertDate)";
                    await connection.ExecuteScalarAsync<int>(query, model);
                }
                return Ok(new MessageAPI("S0001", null, "Create version success!!!"));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

    }

}
