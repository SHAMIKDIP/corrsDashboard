using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corrsDashboard.IRepositories;
using corrsDashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace corrsDashboard.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    
    public class CorrsplantsController : ControllerBase
    {
        private readonly ICorrsplants _corrsPlants;
        public CorrsplantsController(ICorrsplants corrsPlants)
        {
            _corrsPlants = corrsPlants;
        }
        //[HttpGet]
        //[Route("GetCategories")]
        //public async Task<IActionResult> GetCategories()
        //{
        //    try
        //    {
        //        var categories = await _corrsPlants.GetCategories();
        //        if (categories == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(categories);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }

        //}

        [HttpGet]
        [Route("GetAllPlantID")]
        public dynamic getplant()
        {
            return _corrsPlants.getplant();
        }
        
        

    }
}
