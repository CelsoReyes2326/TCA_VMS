using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        [HttpGet("GetUserTypes")]
        public IActionResult Get_UserTypes()
        {
            List<UserType> lstUserTypes = TCA_VMS_DAO.GetUserTypes();
            if (lstUserTypes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lstUserTypes);
            }
        }

        [HttpGet("GetUserType/{id}")]
        public IActionResult Get_UserType(int id)
        {

            var _userType = TCA_VMS_DAO.GetUserType(id);
            if (_userType.UserType_Id > 0)
            {
                return Ok(_userType);
            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost("CreateUserType")]
        public IActionResult Create_UserType([FromBody] UserType userType)
        {

            Result result = new Result();

            if (userType.UserType_Name.Length > 0)
            {
                result = TCA_VMS_DAO.StoreUserType(userType);
                return Ok(result);
            }
            else
            {
                result.Message = "Campos incompletos.";
                result.State = 400;
                return BadRequest(result);
            }

        }

        [HttpPut("UpdateUserType")]
        public IActionResult Update_UserType(UserType userType)
        {
            Result result = new Result();
            if (userType.UserType_Name.Length > 0)
            {
                result = TCA_VMS_DAO.UpdateUserType(userType);
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
