using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsReportController : ControllerBase
    {
        [HttpGet("GetVisitorsReports")]
        public IActionResult Get_VisitorsReports()
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador")
            {
                List<VisitorsReport> lstVisitorsReport = TCA_VMS_DAO.GetVisitorsReports();
                if (lstVisitorsReport == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(lstVisitorsReport);
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

        [HttpGet("GetVisitorsReport/{id}")]
        public IActionResult Get_VisitorsReport(int id)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            if (Rol == "Administrador")
            {
                var _visitorsReport = TCA_VMS_DAO.GetVisitorsReport(id);
                if(_visitorsReport.VisitorsReport_Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_visitorsReport);
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

        [HttpPost("CreateVisitorsReport")]
        public IActionResult Create_VisitorsReport([FromBody] VisitorsReport visitorsReport)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();

            if (Rol == "Administrador")
            {
                if(visitorsReport.Base_Id > 0 && visitorsReport.Company_Id > 0 && visitorsReport.IDType_Id > 0 && visitorsReport.User_Id > 0 && 
                     visitorsReport.VisitorType_Id > 0 && visitorsReport.VisitorsReport_Name.Length > 0 && visitorsReport.VisitorsReport_LastName.Length > 0 
                     && visitorsReport.VisitorsReport_Subject.Length > 0 && visitorsReport.VisitorsReport_Photo.Length > 0
                     && visitorsReport.VisitorsReport_RecievedBy.Length > 0)
                {
                    if (visitorsReport.VisitorsReport_Laptop == true)
                    {
                        if (visitorsReport.VisitorsReport_Laptop_Brand.Length > 0 && visitorsReport.VisitorsReport_Laptop_Serial_Number.Length > 0)
                        {
                            result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
                            return Ok(result);
                        }
                        else
                        {
                            result.Message = "Campos incompletos.";
                            result.State = 400;
                            return BadRequest(result);
                        }
                    }
                    else if(visitorsReport.VisitorsReport_Laptop == false)
                    {
                        result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
                        return Ok(result);
                    }
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

        [HttpPut("UpdateVisitorsReportStatus")]
        public IActionResult Update_VisitorsReport_Status(int id)
        {
            var Usuario = HttpContext.Session.GetString("ActualUser");
            var Rol = HttpContext.Session.GetString("ActualUserRole");
            Result result = new Result();
            if (Rol == "Administrador")
            {
                if(id > 0)
                {
                    result = TCA_VMS_DAO.UpdateVisitorsReport_Status(id);
                    return Ok(result);
                }
                else
                {
                    result.Message = "Identificador no valido.";
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
