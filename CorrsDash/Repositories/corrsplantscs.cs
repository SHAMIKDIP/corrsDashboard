using CorrsDash.IRepositories;
using CorrsDash.Models;
using CorrsDash.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrsDash.Repositories
{
    public class corrsplantscs : ICorrsplants
    {
        corrsdatabaseContext db;
        public corrsplantscs(corrsdatabaseContext _db)
        {
            db = _db;
        }

        public dynamic getplant()
        {
            return db.Corrsplants
              .Select(x => new
              {
                  x.PlantId,
                  x.PlantDomain,
                  x.PlantName,
                  x.Flag
              }).ToArray();
        }

        //public IEnumerable<Corrsplants> GetAllPlantID()
        //{
        //    return db.Corrsplants
        //         .OrderBy(b => b.PlantId)
        //         .ToList();

        //}


        //public async Task<List<Metricbasedreasoncodeview>> GetCategories()
        //{
        //    if (db != null)
        //    {
        //        return await db.Metricbasedreasoncodeview.ToListAsync();
        //    }

        //    return null;
        //}

    }
}
