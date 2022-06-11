using Microsoft.AspNetCore.Mvc;
using WorkshopBasicV2.Models;

namespace WorkshopBasicV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {

        private static List<POSITION> _position = new List<POSITION>
        {
                new POSITION
              {
                  PositionId=10000,
                  PositionName="Dev",


              },
                new POSITION
              {
                  PositionId=10001,
                  PositionName="sale",
              }

        };
        [HttpGet]
        public async Task<ActionResult<List<POSITION>>> Get()
        {
            return _position;
        }

        [HttpPost]
        public async Task<ActionResult<List<POSITION>>> AddPosition([FromBody] POSITION AddPosition)
        {
            _position.Add(AddPosition);
            return Ok(_position);
        }

        [HttpPut]
        public async Task<ActionResult<List<POSITION>>> UpdatePosition([FromBody] POSITION UpdatePosition)
        {
            var Position = _position.Find(x => x.PositionId == UpdatePosition.PositionId);
            if (Position == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");
            }
            else
            {
                Position.PositionName = UpdatePosition.PositionName;

                return Ok(_position);
            }

        }
        [HttpDelete]
        public async Task<ActionResult<List<POSITION>>> DeleteEmployee([FromBody] POSITION DeleteEmployee)
        {
            if (_position.Find(x => x.PositionId == DeleteEmployee.PositionId) == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");
            }
            else
            {
                _position.RemoveAll(x => x.PositionId == DeleteEmployee.PositionId);
                return Ok(_position);
            }

        }

        [HttpGet("{Search}")]
        public async Task<ActionResult<List<POSITION>>> Search(int Search)
        {
            var PositionSearch = _position.Where(x => x.PositionId == Search);
            if (PositionSearch == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");

            }
            else
            {

                return Ok(PositionSearch.Select(it => it.PositionName));
            }


        }
    }
}
