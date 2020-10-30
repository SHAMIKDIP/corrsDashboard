using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorrsDash.IRepositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorrsDash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class MetricsviewController : ControllerBase
    {
        private readonly IMetricsview _imetricsview; 

        public MetricsviewController(IMetricsview imetricsview)
        {
            _imetricsview = imetricsview;
        }
        [HttpGet]
        [Route("GetAllPlantID")]
        public dynamic getplant()
        {
            return _imetricsview.getplantDetails();
        }
        //[HttpGet]
        //[Route("GetMetricsName/{id}")]
        //public async Task<ActionResult> Get(string id)
        //{
        //    var metricName = _imetricsview.getplant(id);
        //    if (metricName == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(metricName);
        //}
    }
}
