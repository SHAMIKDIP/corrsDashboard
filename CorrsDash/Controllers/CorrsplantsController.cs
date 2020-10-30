using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorrsDash.IRepositories;
using CorrsDash.Models;
using CorrsDash.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorrsDash.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    
    public class CorrsplantsController : ControllerBase
    {
        private readonly ICorrsplants _corrsPlants;
        private readonly corrsdatabaseContext _context;
        //private ILoggerManager _logger;
        public CorrsplantsController(ICorrsplants corrsPlants, corrsdatabaseContext context)
        {
            _corrsPlants = corrsPlants;
            _context = context;
        }
        
        [HttpGet]
        [Route("GetAllPlantID")]
        public dynamic getplant()
        {
            try
            {
                return _corrsPlants.getplant();
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        [Route("plantidUpdate")]
        public IActionResult UpdateFlag([FromBody] corrsplantsList cp)
       
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in cp.getCorrsplantlist)
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
            catch {
                return BadRequest();
            }



            
        }

        [HttpPost]
        [Route("Createnewplant")]
        public IActionResult Createnewplant([FromBody] Corrsplants corsplantsdetails )
        {
            var data = _context.Corrsplants.FirstOrDefault(c => c.PlantId == corsplantsdetails.PlantId);
            if (data == null)
            {
                _context.Corrsplants.Add(corsplantsdetails);
                _context.SaveChanges();
            }
            else
            {
                return Ok(corsplantsdetails.PlantId + " already exists");
            }
            return Ok();
        }

    }
}
