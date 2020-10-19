using corrsDashboard.IRepositories;
using corrsDashboard.Models;
using corrsDashboard.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.Repositories
{
    public class corrsplantscs : ICorrsplants
    {
        corrsdatabaseContext db;
        public corrsplantscs(corrsdatabaseContext _db)
        {
            db = _db;
        }

        //public IEnumerable<Corrsplants> GetAllPlantID()
        //{
        //    return db.Corrsplants
        //         .OrderBy(b => b.PlantId)
        //         .ToList();

        //}
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
