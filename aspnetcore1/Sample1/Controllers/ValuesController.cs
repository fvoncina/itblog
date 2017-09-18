using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using Sample1.Entities;

namespace Sample1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private SqlConnection _connection;

        public ValuesController(SqlConnection connection)
        {
            _connection = connection;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rows = await _connection.QueryAsync<Movie>("select * from movies");
            return Ok(rows);
        }
        
    }
}
