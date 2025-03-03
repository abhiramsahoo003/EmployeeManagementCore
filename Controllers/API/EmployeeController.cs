using EmployeeManagementCore.Middleware;
using EmployeeManagementCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementCore.Controllers.API
{
    //[ServiceFilter(typeof(CustomExceptionFilter))]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context) 
        { 
        _context = context;
        }
        // GET: http://localhost:5079/api/employee
        [HttpGet]
        //[ServiceFilter(typeof(CustomExceptionFilter))]
        public List<EmployeeModel> Get()
        {
            return _context.Employee.ToList();
        }

        // GET http://localhost:5079/api/employee/2
        [HttpGet("{id}")]
        public List<EmployeeModel> Get(int id)
        {
            return _context.Employee.Where(a => a.EmployeeId == id).ToList();
        }

        // POST api/<Employee>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Employee>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Employee>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
