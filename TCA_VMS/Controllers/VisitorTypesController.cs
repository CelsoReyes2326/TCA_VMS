using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;
using static TCA_VMS.Models.VisitorType;

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
            if (lstVisitorTypes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lstVisitorTypes);
            }
        }

        [HttpGet("GetVisitorType/{id}")]
        public IActionResult Get_VisitorType(int id)
        {
            var _visitorType = TCA_VMS_DAO.GetVisitorType(id);
            if (_visitorType.VisitorType_Id > 0)
            {
                return Ok(_visitorType);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("CreateVisitorType")]
        public IActionResult Create_IDType([FromBody] VisitorTypePrqst _VisitorType)
        {

            Result result = new Result();
            if(_VisitorType.VisitorType_Name.Length > 0 && _VisitorType.VisitorType_Bagde_Color.Length > 0 && _VisitorType.VisitorType_Bagde_Number.Length > 0)
            {
                result = TCA_VMS_DAO.StoreVisitorType(_VisitorType);
                return Ok(result);
            }
            else
            {
                result.Message = "Campos incompletos.";
                result.State = 400;
                return BadRequest(result);
            }

        }

        [HttpPut("UpdateVisitorType")]
        public IActionResult Update_VisitorType(VisitorType _visitorType)
        {
            Result result = new Result();
            if (_visitorType.VisitorType_Name.Length > 0 && _visitorType.VisitorType_Bagde_Color.Length > 0 && _visitorType.VisitorType_Bagde_Number.Length > 0)
            {
                result = TCA_VMS_DAO.UpdateVisitorType(_visitorType);
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
