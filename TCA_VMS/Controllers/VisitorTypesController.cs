using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorTypesController : ControllerBase
    {
        [HttpGet("GetVisitorTypes")]
        public IActionResult Get_VisitorTypes()
        {
            List<VisitorType> lstVisitorTypes = TCA_VMS_DAO.GetVisitorTypes();
            return Ok(lstVisitorTypes);
        }

        [HttpGet("GetVisitorType/{id}")]
        public IActionResult Get_VisitorType(int id)
        {
            var _visitorType = TCA_VMS_DAO.GetVisitorType(id);
            return Ok(_visitorType);
        }


        [HttpPost("CreateVisitorType")]
        public IActionResult Create_IDType([FromBody] VisitorType _VisitorType)
        {
            Result result = TCA_VMS_DAO.StoreVisitorType(_VisitorType);
            return Ok(result);
        }

        [HttpPut("UpdateVisitorType")]
        public IActionResult Update_VisitorType(VisitorType _visitorType)
        {
            Result result = TCA_VMS_DAO.UpdateVisitorType(_visitorType);

            return Ok(result);
        }
    }
}
