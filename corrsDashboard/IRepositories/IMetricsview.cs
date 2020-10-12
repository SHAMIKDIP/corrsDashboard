using corrsDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.IRepositories
{
   public interface IMetricsview
    {
        //string getMetricsName(string id);
        //dynamic getplant(string PlantDomain);
        dynamic getplantDetails();
    }

}
