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

        [HttpGet("GetBase/{id}")]
        public IActionResult Get_Base(int id)
        {
            var _base = TCA_VMS_DAO.GetBase(id);
            if(_base.Base_Id == 0)
            {
                return NotFound();
            }
            else
            {
            return Ok(_base);
            }
        }


        [HttpPost("CreateBase")]
        public IActionResult Create_Base([FromBody] Base _base)
        {
            Result result = TCA_VMS_DAO.StoreBase(_base);
            return Ok(result);
        }

        [HttpPut("UpdateBase")]
        public IActionResult Update_Base(Base _base)
        {
            Result result = TCA_VMS_DAO.UpdateBase(_base);

            return Ok(result);
        }

    }
}
