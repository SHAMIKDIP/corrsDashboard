using corrsDashboard.IRepositories;
using corrsDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.Repositories
{
    public class metricsview : IMetricsview
    {
        corrsdatabaseContext db;
        public metricsview(corrsdatabaseContext _db)
        {
            db = _db;
        }

        public dynamic getplantDetails()
        {
            return db.Metricsview.Where(s=> s.ReasonCodeApplicability == 1)
             .Select(x => new
             {
                 x.MetricName,
                 x.MetricId,
                 x.PlantDomain,
                 x.PlantId
             }).ToArray();

           
        }

        //public dynamic getplant(string plantID)
        //{ 
        //    return db.Metricsview.Where(e=>e.PlantId ==plantID);
        //}


    }
}
