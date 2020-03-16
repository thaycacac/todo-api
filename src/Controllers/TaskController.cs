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

namespace DapperSeries.Controllers
{
    [Route("api/task")]
    public class TaskController : Controller
    {
        private string _connectionString;

        public TaskController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        
        //GET api/task
        [HttpGet]
        public async Task<IEnumerable<TaskDTO>> Get(string model)
        {
            IEnumerable<TaskDTO> listTask = Enumerable.Empty<TaskDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Task";
                listTask = await connection.QueryAsync<TaskDTO>(query);
            }
            return listTask;
        }


        // GET api/task/1
        [HttpGet("{id}")]
        public async Task<Entities.TaskDTO> Get(int id)
        {
            Entities.TaskDTO task;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Task WHERE Id = @Id";
                task = await connection.QuerySingleAsync<Entities.TaskDTO>(query, new {Id = id});
            }
            return task;
        }

        // POST api/task
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Entities.TaskDTO model)
        {
            int newAircraftId;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Task (title, description, user)
                    VALUES (@title, @description, @user)";
                newAircraftId = await connection.ExecuteScalarAsync<int>(query, model);
            }
            return Ok(newAircraftId);
        }

        // PUT api/task/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskDTO model)
        {
            byte[] rowVersion;
            if (id != model.Id) 
            {
                return BadRequest();
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Task SET
                    tilte = @title
                    ,description = @description
                    ,user = @user
                    WHERE id = @id";
                rowVersion = await connection.ExecuteScalarAsync<byte[]>(query, model);
            }

            if (rowVersion == null) {
                throw new DBConcurrencyException("The entity you were trying to edit has changed. Reload the entity and try again."); 
            }
            return Ok(rowVersion);
        }

        // DELETE api/task/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
        
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE Task WHERE id = @id";
                await connection.ExecuteAsync(query, new {Id = id});
            }
            return Ok();
        }
    }
}
