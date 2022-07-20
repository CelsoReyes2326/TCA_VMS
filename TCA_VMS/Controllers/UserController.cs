using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
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
            if (lstWorkShifts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lstWorkShifts);
            }
        }

        [HttpGet("GetUser/{id}")]
        public IActionResult Get_User(int id)
        {
            var _user = TCA_VMS_DAO.GetUser(id);
            if(_user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_user);
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult Create_User([FromBody] User user)
        {
            Result result = TCA_VMS_DAO.StoreUser(user);
            return Ok(result);
        }

        [HttpPost("CreateUserSA")]
        public IActionResult Create_UserSA([FromBody] User user)
        {
            Result result = TCA_VMS_DAO.StoreUserSA(user);
            return Ok(result);
        }


        [HttpPut("UpdateUser")]
        public IActionResult Update_UserType(User user)
        {
            Result result = TCA_VMS_DAO.UpdateUser(user);

            return Ok(result);
        }

        [HttpGet("GetUserLogin")]
        public IActionResult Login(string username, string password)
        {
            var _password = GetSHA256(password);
            var user = TCA_VMS_DAO.GetUserLogin(username,_password);
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }


        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
