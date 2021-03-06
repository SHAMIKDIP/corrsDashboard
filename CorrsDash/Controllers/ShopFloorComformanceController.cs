﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CorrsDash.IRepositories;
using CorrsDash.Models;
using CorrsDash.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CorrsDash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class ShopFloorComformanceController : Controller
    {
        private readonly IShopFloorComformance _ishopfloorcomformance;
        private readonly corrsdatabaseContext _context;
        Shopfloorcomformance _shopfloorcomformance;
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
                    
                    var reason = _context.Metricbasedreasoncodeview.Where(p => p.MetricId == metricid).Select(q => new
                    {
                        q.ReasonCode,
                        q.ReasonCodeId
                    }).ToArray();

                    var orderdetails = (from shopflor in _context.ShopFloorComformance
                                     join resoncode in _context.ReasonCodes
                                     on shopflor.ReasonCodeId equals resoncode.ReasonCodeId into joinreason
                                     from _reasoncode in joinreason.DefaultIfEmpty()
                                     where shopflor.PlantId == plantid && shopflor.Week == week && shopflor.Flag == "Miss"
                                        //&& _reasoncode.Flag == 1
                                        select new
                                     {
                                         _reasoncode.ReasonCode,
                                         shopflor.ReasonCodeId,
                                         shopflor.Resource,
                                         shopflor.PlantName,
                                         shopflor.PlantId,
                                         shopflor.ProcessOrder,
                                         shopflor.OrderQuantity,
                                         shopflor.MaterialId,
                                         shopflor.MaterialName,
                                         shopflor.OrderQuantityUnit,
                                         shopflor.Flag,
                                         shopflor.FinishDateConfirmed,
                                         shopflor.FinishDateScheduled,
                                         shopflor.ReasonCornerFlag
                                         
                                     }).ToArray();


                    
                   // return new Array[] { orders, reason, reasoncode };
                    return new Array[] {orderdetails, reason };

                    break;
            }
            return null;

        }

        [HttpPut]
        [Route("UpdateShopFloor")]
        public IActionResult Edit([FromBody] ShopFloorMetricDetails shopFloor)
        {
            foreach (var item in shopFloor.shopFloorMetricDetails)
            {
                switch (item.MetricId)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 5:
                        var data = _ishopfloorcomformance.GetDetailsByIDs(item.Resource, item.ProcessOrder);
                        if (data != null)
                        {
                            data.ReasonCornerFlag = item.Reasoncornerflag;
                            data.ReasonCodeId = item.ReasonCodeId;
                            //_context.Entry(data).State = EntityState.Detached;

                            if (ModelState.IsValid)
                            {
                                _ishopfloorcomformance.UpdateShopFloorComformance(data);
                            }
                        }
                        break;
                }
            }
            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
