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
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador")
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
            else
            {
                Result result = new Result();
                if (Rol == null)
                {
                    result.Message = "Es necesario iniciar sesion.";
                    result.State = 403;
                    return NotFound(result);
                }
                else
                {
                    result.Message = "Usuario sin accesso.";
                    result.State = 403;
                    return NotFound(result);
                }
            }
        }

        [HttpGet("GetVisitorType/{id}")]
        public IActionResult Get_VisitorType(int id)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador")
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
            else
            {
                Result result = new Result();
                if (Rol == null)
                {
                    result.Message = "Es necesario iniciar sesion.";
                    result.State = 403;
                    return NotFound(result);
                }
                else
                {
                    result.Message = "Usuario sin accesso.";
                    result.State = 403;
                    return NotFound(result);
                }
            }
        }


        [HttpPost("CreateVisitorType")]
        public IActionResult Create_IDType([FromBody] VisitorType _VisitorType)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
                result = TCA_VMS_DAO.StoreVisitorType(_VisitorType);
                return Ok(result);
            }
            else
            {
                if (Rol == null)
                {
                    result.Message = "Es necesario iniciar sesion.";
                    result.State = 403;
                    return NotFound(result);
                }
                else
                {
                    result.Message = "Usuario sin accesso.";
                    result.State = 403;
                    return NotFound(result);
                }
            }
        }

        [HttpPut("UpdateVisitorType")]
        public IActionResult Update_VisitorType(VisitorType _visitorType)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
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
            else
            {
                if (Rol == null)
                {
                    result.Message = "Es necesario iniciar sesion.";
                    result.State = 403;
                    return NotFound(result);
                }
                else
                {
                    result.Message = "Usuario sin accesso.";
                    result.State = 403;
                    return NotFound(result);
                }
            }
        }
    }
}
