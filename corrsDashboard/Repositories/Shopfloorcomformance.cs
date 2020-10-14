using corrsDashboard.IRepositories;
using corrsDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.Repositories
{
    public class Shopfloorcomformance : IShopFloorComformance
    {
        corrsdatabaseContext db;
        
        public Shopfloorcomformance(corrsdatabaseContext _db)
        {
            db = _db;
        }

        //public ShopFloorComformance GetDetailsByIds(string resource, long processorder)
        //{
        //    return db.ShopFloorComformance.FirstOrDefault(s => s.Resource == resource && s.ProcessOrder == processorder);
        //}

        //public void UpdateShopFloorComformance(ShopFloorComformance shopFloor)
        //{
        //    db.ShopFloorComformance.Update(shopFloor);

        //    db.SaveChanges();

        //}



        //public dynamic Displaymissedorders(string plantid, int metricid, int week)
        //{
        //    switch(metricid)
        //    {
        //        case 5:
        //            return db.ShopFloorComformance.Where(b => b.PlantId == plantid && (b.Week == week && b.Flag == "Miss"))
        //.Select(x => new
        //{
        //    x.OrderQuantity,
        //    x.MaterialId,
        //    x.MaterialName,
        //    x.OrderQuantityUnit,
        //    x.FinishDateConfirmed,
        //    x.FinishDateScheduled
        //}).ToArray();

        //         break;

        //    }
        //    return null;
        //}


    }
}
