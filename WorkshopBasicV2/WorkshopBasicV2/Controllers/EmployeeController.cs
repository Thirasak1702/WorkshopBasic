using Microsoft.AspNetCore.Mvc;
using WorkshopBasicV2.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkshopBasicV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<EMPLOYEE> _employee = new List<EMPLOYEE>
        {
                new EMPLOYEE
              {
                  EmployeeId=65000,
                  EmployeeName="Thirasak",
                  EmployeeAddress="1045",
                  Age=31,
                  Tel="0644799356",
                  Salary=15000

              },
                new EMPLOYEE
              {
                  EmployeeId=65001,
                  EmployeeName="Somsak",
                  EmployeeAddress="777",
                  Age=30,
                  Tel="0850117694",
                  Salary=20000

              }

        };
        [HttpGet]
        public async Task<ActionResult<List<EMPLOYEE>>> Get()
        {
            return _employee;
        }

        [HttpPost]
        public async Task<ActionResult<List<EMPLOYEE>>> AddEmployee([FromBody] EMPLOYEE AddEmployee)
        {
            _employee.Add(AddEmployee);
            return Ok(_employee);
        }

        [HttpPut]
        public async Task<ActionResult<List<EMPLOYEE>>> UpdateEmployee([FromBody] EMPLOYEE UpdateEmployee)
        {
            var Employee = _employee.Find(x => x.EmployeeId == UpdateEmployee.EmployeeId);
            if (Employee == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");
            }
            else
            {
                Employee.EmployeeName = UpdateEmployee.EmployeeName;
                Employee.EmployeeAddress = UpdateEmployee.EmployeeAddress;
                return Ok(_employee);
            }

        }
        [HttpDelete]
        public async Task<ActionResult<List<EMPLOYEE>>> DeleteEmployee([FromBody] EMPLOYEE DeleteEmployee)
        {
            if (_employee.Find(x => x.EmployeeId == DeleteEmployee.EmployeeId) == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");
            }
            else
            {
                _employee.RemoveAll(x => x.EmployeeId == DeleteEmployee.EmployeeId);
                return Ok(_employee);
            }

        }

        [HttpGet("{Search}")]
        public async Task<ActionResult<List<EMPLOYEE>>> Search(int Search)
        {
            var EmployeeSearch = _employee.Where(x => x.EmployeeId == Search);
            if (EmployeeSearch == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");

            }
            else
            {

                return Ok(EmployeeSearch.Select(it => it.EmployeeName));
            }


        }
      
    }
}
