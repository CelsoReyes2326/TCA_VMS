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

        [HttpGet("GetWorkShift/{id}")]
        public IActionResult Get_UserType(int id)
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


        [HttpPost("CreateWorkShift")]
        public IActionResult Create_WorkShift([FromBody] WorkShift workShift)
        {

            Result result = new Result();

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

        [HttpPut("UpdateWorkShift")]
        public IActionResult Update_WorkShift(WorkShift workShift)
        {

            Result result = new Result();

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
    }
}
