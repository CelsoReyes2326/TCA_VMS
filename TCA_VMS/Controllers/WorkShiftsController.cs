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
            return Ok(lstWorkShifts);
        }

        [HttpGet("GetWorkShift/{id}")]
        public IActionResult Get_UserType(int id)
        {
            var _workShift = TCA_VMS_DAO.GetWorkShift(id);
            return Ok(_workShift);
        }


        [HttpPost("CreateWorkShift")]
        public IActionResult Create_UserType([FromBody] WorkShift workShift)
        {
            Result result = TCA_VMS_DAO.StoreWorkShift(workShift);
            return Ok(result);
        }

        [HttpPut("UpdateWorkShift")]
        public IActionResult Update_UserType(WorkShift workShift)
        {
            Result result = TCA_VMS_DAO.UpdateWorkShift(workShift);

            return Ok(result);
        }
    }
}
