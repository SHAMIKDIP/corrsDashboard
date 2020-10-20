﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using corrsDashboard.IRepositories;
using corrsDashboard.Models;
using corrsDashboard.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace corrsDashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AddReasonCodeController : Controller
    {
        private readonly IAddreasoncode _iaddreasoncode;
        private readonly corrsdatabaseContext _context;
        public ReasonCodes _reasoncodes;
        public Corrsmetricreasoncodedependency _metricdetails;
        public AddReasonCodeController(IAddreasoncode iaddreasoncode, corrsdatabaseContext context)
        {
            _iaddreasoncode = iaddreasoncode;
            _context = context;
        }
        [HttpGet]
        [Route("Getallreasoncode")]
        public async Task<IActionResult> Getallreasoncode()
        {
            try
            {
                var categories = await _iaddreasoncode.Getallreasoncode();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("SaveReasoncode")]
        public IActionResult Create([FromBody] MetricbasedreasoncodeDetails reasonCodes)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in reasonCodes.MetricreasoncodeviewDetails)
                {
                    //var dataExists = _context.Corrsmetricreasoncodedependency
                    //    .FirstOrDefault(c => c.Reason.ReasonCode == item.ReasonCode);
                    var dataExists = _context.ReasonCodes.FirstOrDefault(c => c.ReasonCode == item.ReasonCode);
                    if (dataExists == null)
                    {
                        ReasonCodes codes = new ReasonCodes();
                        codes.ReasonCode = item.ReasonCode;
                        //codes.Flag = item.Flag;
                        _iaddreasoncode.AddReasonCodes(codes, (int)item.MetricId, (int)item.Flag);
                    }
                    else //if (dataExists.ReasonId != 0)
                    {
                        return Ok(item.ReasonCode + " already exists");
                    }

                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("AddNewReasoncode")]
        //public IActionResult Addreasoncode(string reasoncodename, [FromBody] MetricbasedreasoncodeDetails reasonCodes, reasoncodename)
        public IActionResult Addreasoncode([FromBody] MetricbasedreasoncodeDetails reasonCodes)
        {
            if (ModelState.IsValid)
            {
                //var reasocode = reasonCodes.MetricreasoncodeviewDetails.ReasonCode;
                //reasocode.Reason
                var data = _context.ReasonCodes.FirstOrDefault(c => c.ReasonCode == reasonCodes.reasoncodename);
                //var data = _context.ReasonCodes.FirstOrDefault(c => c.ReasonCode == reasonCodes);
                if (data == null)
                {
                    foreach (var item in reasonCodes.MetricreasoncodeviewDetails)
                    {
                        ReasonCodes codes = new ReasonCodes();
                        codes.ReasonCode = reasonCodes.reasoncodename;
                        //codes.Flag = item.Flag;
                        _iaddreasoncode.AddReasonCodes(codes, (int)item.MetricId, (int)item.Flag);
                    }
                }
                else
                {
                    return Ok(reasonCodes.reasoncodename + " already exists");

                }
            }
            return Ok();
        }
        [HttpPut]
        [Route("Reasoncodeupdate")]
        public IActionResult UpdateFlag([FromBody] MetricbasedreasoncodeDetails rc)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in rc.MetricDetails)
                {
                    //var data = _context.Corrsmetricreasoncodedependency.FirstOrDefault(s => s.Reason.ReasonCodeId == item.Reason.ReasonCodeId && s.MetricId == item.MetricId);
                    var data = _context.Corrsmetricreasoncodedependency
                         .Include(r => r.Reason).FirstOrDefault(s => s.ReasonId == item.ReasonId && s.MetricId == item.MetricId);

                    if (data != null)
                    {
                        data.Flag = item.Flag;
                        data.ReasonId = item.ReasonId;
                        data.MetricId = item.MetricId;
                        _context.Corrsmetricreasoncodedependency.Update(data);
                        _context.SaveChanges();
                    }
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
