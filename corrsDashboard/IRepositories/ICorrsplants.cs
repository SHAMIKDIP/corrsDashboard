
using corrsDashboard.Models;
using corrsDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.IRepositories
{
    public interface ICorrsplants
    {
        //Task<List<Metricbasedreasoncodeview>> GetCategories();
        dynamic getplant();
        IEnumerable<Corrsplants> GetAllPlantID();
        
    }
}
