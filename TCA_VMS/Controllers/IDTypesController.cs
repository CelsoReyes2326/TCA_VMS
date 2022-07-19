using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IDTypesController : ControllerBase
    {
        [HttpGet("GetIDTypes")]
        public IActionResult Get_IDTypes()
        {
            List<IDType> lstIDTypes = TCA_VMS_DAO.GetIDTypes();
            return Ok(lstIDTypes);
        }

        [HttpGet("GetIDType/{id}")]
        public IActionResult Get_IDType(int id)
        {
            var _IDType = TCA_VMS_DAO.GetIDType(id);
            return Ok(_IDType);
        }


        [HttpPost("CreateIDType")]
        public IActionResult Create_IDType([FromBody] IDType _IDType)
        {
            Result result = TCA_VMS_DAO.StoreIDType(_IDType);
            return Ok(result);
        }

        [HttpPut("UpdateIDType")]
        public IActionResult Update_IDType(IDType _IDType)
        {
            Result result = TCA_VMS_DAO.UpdateIDType(_IDType);

            return Ok(result);
        }
    }
}
