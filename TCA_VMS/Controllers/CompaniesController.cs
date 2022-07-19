using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {

        [HttpGet("GetCompanies")]
        public IActionResult Get_Companies()
        {
            List<Company> lstCompanies = TCA_VMS_DAO.GetCompanies();
            return Ok(lstCompanies);
        }

        [HttpGet("GetCompany/{id}")]
        public IActionResult Get_Company(int id)
        {
            var _company = TCA_VMS_DAO.GetCompany(id);
            return Ok(_company);
        }


        [HttpPost("CreateCompany")]
        public IActionResult Create_Company([FromBody] Company _company)
        {
            Result result = TCA_VMS_DAO.StoreCompany(_company);
            return Ok(result);
        }

        [HttpPut("UpdateCompany")]
        public IActionResult Update_Base(Company _company)
        {
            Result result = TCA_VMS_DAO.UpdateCompany(_company);

            return Ok(result);
        }




    }
}
