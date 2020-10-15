using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corrsDashboard.IRepositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace corrsDashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class AddReasonCodeController : Controller
    {
        private readonly IAddreasoncode _iaddreasoncode;
        public AddReasonCodeController(IAddreasoncode iaddreasoncode)
        {
            _iaddreasoncode = iaddreasoncode;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
