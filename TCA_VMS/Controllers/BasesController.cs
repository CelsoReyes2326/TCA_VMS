using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController : ControllerBase
    {
        [HttpGet("GetBases")]
        public IActionResult Get_Bases()
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador") //agregar mas roles
            {
                List<Base> lstBases = TCA_VMS_DAO.GetBases();
                if(lstBases == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(lstBases);
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

        [HttpGet("GetBase/{id}")]
        public IActionResult Get_Base(int id)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador")
            {
                var _base = TCA_VMS_DAO.GetBase(id);
                if (_base.Base_Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_base);
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

        [HttpPost("CreateBase")]
        public IActionResult Create_Base([FromBody] Base _base)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
                if(_base.Base_Location.Length > 0 && _base.Base_Name.Length > 0)
                {
                    result = TCA_VMS_DAO.StoreBase(_base);
                    return Ok(result);
                }
                else
                {
                    result.State = 1;
                    result.Message = "Verifique los datos";
                    return Ok(result);
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

        [HttpPut("UpdateBase")]
        public IActionResult Update_Base(Base _base)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
                if (_base.Base_Location.Length > 0 && _base.Base_Name.Length > 0)
                {
                    result = TCA_VMS_DAO.UpdateBase(_base);
                    return Ok(result);
                }
                else
                {
                    result.State = 1;
                    result.Message = "Verifique los datos";
                    return Ok(result);
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
