using CorrsDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrsDash.IRepositories
{
   public interface IShopFloorComformance
    {
        ShopFloorComformance GetDetailsByIDs(string resource, long processOrder);
        void UpdateShopFloorComformance(ShopFloorComformance shopFloor);
        //public void UpdateShopFloorComformance(ShopFloorComformance shopFloor);
        //public ShopFloorComformance GetDetailsByIds(string resource,long processorder);
        // Task<ShopFloorComformance> Displaymissedorders(string plantid, int metricid, int week);
        //dynamic Displaymissedorders(string plantid, int metricid, int week);
    }
}
//