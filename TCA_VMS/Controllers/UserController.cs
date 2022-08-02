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
            List<User> lstUsers = TCA_VMS_DAO.GetUsers();
            if (lstUsers == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lstUsers);
            }
        }

        [HttpGet("GetUser/{id}")]
        public IActionResult Get_User(int id)
        {
            var _user = TCA_VMS_DAO.GetUser(id);
            if (_user == null)
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
            Result result = new Result();

            if (user.Base_Id > 0 && user.UserType_Id > 0 && user.WorkShift_Id > 0 && user.User_Name.Length > 0
                && user.UserName.Length > 0 && user.User_Last_Name.Length > 0 && user.User_Email.Length > 0
                && user.User_Password.Length > 0)
            {
                result = TCA_VMS_DAO.StoreUser(user);
                return Ok(result);
            }
            else
            {
                result.State = 403;
                result.Message = "Verifique los datos, modelo no valido.";
                return Ok(result);
            }
        }

        [HttpPost("CreateUserSA")]
        public IActionResult Create_UserSA([FromBody] User user)
        {
            Result result = new Result();
            if (user.Base_Id > 0 && user.UserType_Id > 0 && user.WorkShift_Id > 0 && user.User_Name.Length > 0 
                && user.UserName.Length > 0 && user.User_Last_Name.Length > 0 && user.User_Email.Length > 0 
                && user.User_Password.Length > 0)
            {
                result = TCA_VMS_DAO.StoreUserSA(user);
                return Ok(result);
            }
            else
            {
                result.State = 400;
                result.Message = "Verifique los datos";
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateUser")]
        public IActionResult Update_UserType(User user)
        {

            Result result = new Result();
            if (user.Base_Id > 0 && user.UserType_Id > 0 && user.WorkShift_Id > 0 && user.User_Name.Length > 0
                && user.UserName.Length > 0 && user.User_Last_Name.Length > 0 && user.User_Email.Length > 0
                && user.User_Password.Length > 0 && user.User_Status || user.User_Status == false)
            {
                result = TCA_VMS_DAO.UpdateUser(user);
                return Ok(result);
            }
            else
            {
                result.State = 400;
                result.Message = "Verifique los datos";
                return BadRequest(result);
            }
           
        }

        [HttpGet("GetUserLogin/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            var _password = GetSHA256(password);
            var user = TCA_VMS_DAO.GetUserLogin(username, _password);
            if (user == null || user.User_Id == 0)
            {
                Result result = new Result();
                result.State = 404;
                result.Message = "Usuario no encontrado.";
                return NotFound(result);
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet("UserLogOut")]
        public IActionResult LogOut()
        {
            return Ok();
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
