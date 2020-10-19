using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corrsDashboard.IRepositories;
using corrsDashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace corrsDashboard.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    
    public class CorrsplantsController : ControllerBase
    {
        private readonly ICorrsplants _corrsPlants;
        private readonly corrsdatabaseContext _context;
        public CorrsplantsController(ICorrsplants corrsPlants, corrsdatabaseContext context)
        {
            _corrsPlants = corrsPlants;
            _context = context;
        }
        
        [HttpGet]
        [Route("GetAllPlantID")]
        public dynamic getplant()
        {
            return _corrsPlants.getplant();
        }

        [HttpPut]
        [Route("plantidUpdate")]
        public IActionResult UpdateFlag([FromBody] corrsplantsList cp)
       
        {
            if (ModelState.IsValid)
            {
                foreach (var item in cp.corrsPlantList)
                {
                    var data = _context.Corrsplants.FirstOrDefault(s => s.PlantId == item.PlantId);
                    
                    if (data != null)
                    {

                        data.Flag = item.Flag;
                        _context.Corrsplants.Update(data);
                        _context.Entry(data).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    
                    
                }
            }

            return Ok();
        }

    }
}
