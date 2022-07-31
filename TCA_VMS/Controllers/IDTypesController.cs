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
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador") //agregar mas roles
            {
                List<IDType> lstIDTypes = TCA_VMS_DAO.GetIDTypes();
                if(lstIDTypes == null) 
                {
                    return NotFound();
                } 
                else
                {
                    return Ok(lstIDTypes);
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

        [HttpGet("GetIDType/{id}")]
        public IActionResult Get_IDType(int id)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador")
            {
                var _IDType = TCA_VMS_DAO.GetIDType(id);
                if (_IDType.IDType_Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_IDType);
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


        [HttpPost("CreateIDType")]
        public IActionResult Create_IDType([FromBody] IDType _IDType)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
                if (_IDType.IDType_Name.Length > 0)
                {
                    result = TCA_VMS_DAO.StoreIDType(_IDType);
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

        [HttpPut("UpdateIDType")]
        public IActionResult Update_IDType(IDType _IDType)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
                if (_IDType.IDType_Name.Length > 0)
                {
                    result = TCA_VMS_DAO.UpdateIDType(_IDType);
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
