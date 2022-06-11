using Microsoft.AspNetCore.Mvc;
using WorkshopBasicV2.Models;


namespace WorkshopBasicV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private static List<DEPARTMEN> _department = new List<DEPARTMEN>
        {
                new DEPARTMEN
              {
                  DepartmentId=20000,
                  DepartmentName="IT",
                  Tel="020123456"

              },
                new DEPARTMEN
              {
                  DepartmentId=20001,
                  DepartmentName="FINANCE",
                  Tel="020987654"
              }

        };
        [HttpGet]
        public async Task<ActionResult<List<DEPARTMEN>>> Get()
        {
            return _department;
        }

        [HttpPost]
        public async Task<ActionResult<List<DEPARTMEN>>> AddPosition([FromBody] DEPARTMEN AddDepartment)
        {
            _department.Add(AddDepartment);
            return Ok(_department);
        }

        [HttpPut]
        public async Task<ActionResult<List<DEPARTMEN>>> UpdateDepartment([FromBody] DEPARTMEN UpdateDepartment)
        {
            var Department = _department.Find(x => x.DepartmentId == UpdateDepartment.DepartmentId);
            if (Department == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");
            }
            else
            {
                Department.DepartmentName = UpdateDepartment.DepartmentName;
                Department.Tel = UpdateDepartment.Tel;
                return Ok(_department);
            }

        }
        [HttpDelete]
        public async Task<ActionResult<List<DEPARTMEN>>> DeleteDepartment([FromBody] DEPARTMEN DeleteDepartment)
        {
            if (_department.Find(x => x.DepartmentId == DeleteDepartment.DepartmentId) == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");
            }
            else
            {
                _department.RemoveAll(x => x.DepartmentId == DeleteDepartment.DepartmentId);
                return Ok(_department);
            }

        }

        [HttpGet("{Search}")]
        public async Task<ActionResult<List<DEPARTMEN>>> Search(int Search)
        {
            var DepartmentSearch = _department.Where(x => x.DepartmentId == Search);
            if (DepartmentSearch == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");

            }
            else
            {

                return Ok(DepartmentSearch.Select(it => it.DepartmentName));
            }


        }
    }
}
