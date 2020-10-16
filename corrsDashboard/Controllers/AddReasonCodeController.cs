using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using corrsDashboard.IRepositories;
using corrsDashboard.Models;
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
                foreach (var item in reasonCodes.MetricbasedreasoncodeviewDetails)
                {
                    var dataExists = _context.Corrsmetricreasoncodedependency
                        .FirstOrDefault(c => c.MetricId == item.MetricId && c.Reason.ReasonCode == item.ReasonCode);

                    //var dataExists = _context.Corrsmetricreasoncodedependency
                    //    .Include(r => r.Reason).FirstOrDefault(c => c.Metric.MetricName == item.MetricName && c.Reason.ReasonCode == item.ReasonCode);

                    if (dataExists == null)
                    {
                        ReasonCodes codes = new ReasonCodes();
                        codes.ReasonCode = item.ReasonCode;
                        codes.Flag = item.Flag;
                        _iaddreasoncode.AddReasonCodes(codes, (int)item.MetricId);
                    }
                }
            }
            return Ok();
        }

        [HttpPut]
        [Route("Reasoncodeupdate")]
        public IActionResult UpdateFlag([FromBody] ReasoncodeList rc)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in rc.ReasonCodeList)
                {
                    var data = _context.ReasonCodes.FirstOrDefault(s => s.ReasonCodeId == item.ReasonCodeId);
                    if (data != null)
                    {
                        data.Flag = item.Flag;
                        _context.ReasonCodes.Update(data);
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
