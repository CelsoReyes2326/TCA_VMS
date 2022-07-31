using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShiftsController : ControllerBase
    {
        [HttpGet("GetWorkShifts")]
        public IActionResult Get_WorkShifts()
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador")
            {
                List<WorkShift> lstWorkShifts = TCA_VMS_DAO.GetWorkShifts();
                if (lstWorkShifts == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(lstWorkShifts);
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

        [HttpGet("GetWorkShift/{id}")]
        public IActionResult Get_UserType(int id)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador")
            {
                var _workShift = TCA_VMS_DAO.GetWorkShift(id);
                if (_workShift.WorkShift_Id > 0)
                {
                    return Ok(_workShift);
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


        [HttpPost("CreateWorkShift")]
        public IActionResult Create_WorkShift([FromBody] WorkShift workShift)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
                if (workShift.WorkShift_Name.Length > 0 && workShift.WorkShift_Start_Hour.Length > 0 && workShift.WorkShift_Out_Hour.Length > 0)
                {
                    result = TCA_VMS_DAO.StoreWorkShift(workShift);
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

        [HttpPut("UpdateWorkShift")]
        public IActionResult Update_WorkShift(WorkShift workShift)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
                if (workShift.WorkShift_Id > 0 && workShift.WorkShift_Name.Length > 0 && workShift.WorkShift_Start_Hour.Length > 0 && workShift.WorkShift_Out_Hour.Length > 0)
                {
                    result = TCA_VMS_DAO.UpdateWorkShift(workShift);
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
