using System;
using System.Collections.Generic;
using System.Linq;
using corrsDashboard.IRepositories;
using corrsDashboard.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace corrsDashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class ShopFloorComformanceController : Controller
    {
        private readonly IShopFloorComformance _ishopfloorcomformance;
        private readonly corrsdatabaseContext _context;
        
        public ShopFloorComformanceController(IShopFloorComformance ishopfloorcomformance, corrsdatabaseContext context)
        {
            _ishopfloorcomformance = ishopfloorcomformance;
            _context = context;

        }

        //[Route("Displaymissedorders")]
        //public dynamic Displaymissedorders(string plantid, int metricid, int week)
        //{
        //    return _ishopfloorcomformance.Displaymissedorders(plantid, metricid, week);
        //}
        [HttpPost]
        [Route("Displaymissedorders")]
        public dynamic Displaymissedorders(string plantid, int metricid, int week)
        {

            switch (metricid)
            {
                case 1:
                    break;
                case 5:
                    var orders = _context.ShopFloorComformance.Where(b => b.PlantId == plantid && (b.Week == week && b.Flag == "Miss"))
 .Select(x => new
 {
     x.OrderQuantity,
     x.MaterialId,
     x.MaterialName,
     x.OrderQuantityUnit,
     x.FinishDateConfirmed,
     x.FinishDateScheduled
 }).ToArray();
                    var reason = _context.Metricbasedreasoncodeview.Where(p => p.MetricId == metricid).Select(q => new
                    {
                        q.ReasonCode
                    }).ToArray();


                    return new Array[] {orders,reason };
                    

                    break;
            }
            return null;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
