using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using System.Data;
using Dapper;
using DapperSeries.Entities;
using BenchmarkDotNet.Running;

namespace DapperSeries.Controllers
{
    [Route("api/scheduledflight")]
    public class UserController : Controller
    {
        private string _connectionString;

        public UserController(IConfiguration configuration)
        {
            if (configuration != null)
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            else
            {
                _connectionString = "Server=DESKTOP-G4NBSB1;Database=TODOLIST;ConnectRetryCount=0;Trusted_Connection=True;MultipleActiveResultSets=true";
            }
        }

        //GET api/user?username=h
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get(string from)
        {
            IEnumerable<UserDTO> users;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = @"SELECT * FROM User%";

                users = await connection.QueryAsync<UserDTO>(query);
            }
            return users;
        }
    }
}
