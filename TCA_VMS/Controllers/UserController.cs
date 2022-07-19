using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models;
using TCA_VMS.Models.DAO;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetUsers")]
        public IActionResult Get_Users()
        {
            List<User> lstWorkShifts = TCA_VMS_DAO.GetUsers();
            return Ok(lstWorkShifts);
        }

        [HttpGet("GetUser/{id}")]
        public IActionResult Get_User(int id)
        {
            var _user = TCA_VMS_DAO.GetUser(id);
            return Ok(_user);
        }

        [HttpPost("CreateUser")]
        public IActionResult Create_User([FromBody] User user)
        {
            Result result = TCA_VMS_DAO.StoreUser(user);
            return Ok(result);
        }


        [HttpPut("UpdateUser")]
        public IActionResult Update_UserType(User user)
        {
            Result result = TCA_VMS_DAO.UpdateUser(user);

            return Ok(result);
        }

    }
}
