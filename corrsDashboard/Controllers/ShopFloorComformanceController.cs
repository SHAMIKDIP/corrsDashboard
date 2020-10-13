using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


        public dynamic Displaymissedorders([FromBody] orderdetails od )
        {
            string plantid = od.plantid;
            int metricid = od.metricid;
            int week = od.week;

            switch (metricid)
            {
                case 1:
                    break;
                case 5:
                    var orders = _context.ShopFloorComformance.Where(b => b.PlantId == plantid && (b.Week == week && b.Flag == "Miss"))
                     .Select(x => new
                     {
                         x.ResourceName,
                         x.PlantName,
                         x.PlantId,
                         x.ProcessOrder,
                         x.OrderQuantity,
                         x.MaterialId,
                         x.MaterialName,
                         x.OrderQuantityUnit,
                         x.Flag,
                         x.FinishDateConfirmed,
                         x.FinishDateScheduled
                     }).ToArray();
                    var reason = _context.Metricbasedreasoncodeview.Where(p => p.MetricId == metricid).Select(q => new
                    {
                        q.ReasonCode,
                        q.ReasonCodeId
                    }).ToArray();

                    //var reasoncode = (from p in _context.ShopFloorComformance
                    // join e in _context.ReasonCodes
                    // on p.ReasonCode equals e.ReasonCode
                    //          select new
                    // {
                    //     e.ReasonCode
                    // }).ToArray();


                    var reasoncode = (from p in _context.ShopFloorComformance
                                      join e in _context.ReasonCodes
                                      on p.ReasonCode equals e.ReasonCode
                                      //where p.PlantId == plantid && p.Week == week && p.Flag == "Miss"
                                      select new
                                      {
                                          e.ReasonCode,
                                          //p.ResourceName,
                                          //p.PlantName,
                                          //p.PlantId,
                                          //p.ProcessOrder,
                                          //p.OrderQuantity,
                                          //p.MaterialId,
                                          //p.MaterialName,
                                          //p.OrderQuantityUnit,
                                          //p.Flag,
                                          //p.FinishDateConfirmed,
                                          //p.FinishDateScheduled
                                      }).ToArray();



                    
                    return new Array[] { orders, reason, reasoncode };

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
