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
            if (lstCompanies == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lstCompanies);
            }
        }

        [HttpGet("GetCompany/{id}")]
        public IActionResult Get_Company(int id)
        {
            var _company = TCA_VMS_DAO.GetCompany(id);
            if (_company.Company_Id == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(_company);
            }
        }


        [HttpPost("CreateCompany")]
        public IActionResult Create_Company([FromBody] Company _company)
        {

            Result result = new Result();
            if (_company.Company_Name.Length > 0 && _company.Company_Address.Length > 0 && _company.Company_Phone_Number.Length > 0)
            {
                result = TCA_VMS_DAO.StoreCompany(_company);
                return Ok(result);
            }
            else
            {
                result.Message = "Campos incompletos.";
                result.State = 400;
                return BadRequest(result);
            }

        }

        [HttpPut("UpdateCompany")]
        public IActionResult Update_Company(Company _company)
        {

            Result result = new Result();
            if (_company.Company_Name.Length > 0 && _company.Company_Address.Length > 0 && _company.Company_Phone_Number.Length > 0)
            {
                result = TCA_VMS_DAO.UpdateCompany(_company);
                return Ok(result);
            }
            else
            {
                result.Message = "Campos incompletos.";
                result.State = 400;
                return BadRequest(result);
            }
        }
    }
}
