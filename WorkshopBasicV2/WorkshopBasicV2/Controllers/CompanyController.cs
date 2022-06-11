using Microsoft.AspNetCore.Mvc;
using WorkshopBasicV2.Models;


namespace WorkshopBasicV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private static List<COMPANY> _companny = new List<COMPANY>
        {
                new COMPANY
              {
                  CompanyId=30000,
                  CompanyName="BANANA",
                  CompanyAddress="222",
                  Year=1990,
                  Description="COM Mobile"

              },
                new COMPANY
              {
                  CompanyId=30001,
                  CompanyName="SoftASSET",
                  CompanyAddress="555",
                  Year=1991,
                  Description="POS"
              }

        };
        [HttpGet]
        public async Task<ActionResult<List<COMPANY>>> Get()
        {
            return _companny;
        }

        [HttpPost]
        public async Task<ActionResult<List<COMPANY>>> AddPosition([FromBody] COMPANY AddCompany)
        {
            _companny.Add(AddCompany);
            return Ok(_companny);
        }

        [HttpPut]
        public async Task<ActionResult<List<COMPANY>>> UpdateCompany([FromBody] COMPANY UpdateCompany)
        {
            var Company = _companny.Find(x => x.CompanyId == UpdateCompany.CompanyId);
            if (Company == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");
            }
            else
            {
                Company.CompanyName = UpdateCompany.CompanyName;
                Company.CompanyAddress = UpdateCompany.CompanyAddress;
                Company.Year = UpdateCompany.Year;
                Company.Description = UpdateCompany.Description;
                return Ok(_companny);
            }

        }
        [HttpDelete]
        public async Task<ActionResult<List<COMPANY>>> DeleteCompany([FromBody] COMPANY DeleteCompany)
        {
            if (_companny.Find(x => x.CompanyId == DeleteCompany.CompanyId) == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");
            }
            else
            {
                _companny.RemoveAll(x => x.CompanyId == DeleteCompany.CompanyId);
                return Ok(_companny);
            }

        }

        [HttpGet("{Search}")]
        public async Task<ActionResult<List<COMPANY>>> Search(int Search)
        {
            var CompanySearch = _companny.Where(x => x.CompanyId == Search);
            if (CompanySearch == null)
            {
                return BadRequest("Unable to update information, please enter EmployeeId again.");

            }
            else
            {

                return Ok(CompanySearch.Select(it => it.CompanyName));
            }


        }
    }
}
