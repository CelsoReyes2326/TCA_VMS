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
        [HttpPost("CreateVisitorsReport")]
        public IActionResult Create_VisitorsReport([FromBody] VisitorsReport visitorsReport)
        {
            Result result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
            return Ok(result);
        }

        [HttpGet("GetVisitorsReports")]
        public IActionResult Get_VisitorsReports()
        {
            List<VisitorsReport> lstVisitorsReport = TCA_VMS_DAO.GetVisitorsReports();
            return Ok(lstVisitorsReport);
        }


        [HttpGet("GetVisitorsReport/{id}")]
        public IActionResult Get_VisitorsReport(int id)
        {
            var _visitorsReport = TCA_VMS_DAO.GetVisitorsReport(id);
            return Ok(_visitorsReport);
        }

        [HttpPut("UpdateVisitorsReportStatus")]
        public IActionResult Update_VisitorsReport_Status(int id)
        {
            Result result = TCA_VMS_DAO.UpdateVisitorsReport_Status(id);

            return Ok(result);
        }

    }
}
