﻿using CorrsDash.IRepositories;
using CorrsDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrsDash.Repositories
{
    public class Shopfloorcomformance : IShopFloorComformance
    {
        corrsdatabaseContext db;
        
        public Shopfloorcomformance(corrsdatabaseContext _db)
        {
            db = _db;
        }

       
        public ShopFloorComformance GetDetailsByIDs(string resource, long processOrder)
        {
            return db.ShopFloorComformance.FirstOrDefault(s => s.Resource == resource && s.ProcessOrder == processOrder);
        }
        public void UpdateShopFloorComformance(ShopFloorComformance shopFloor)
        {
            //_context.Entry(shopFloor).State = EntityState.Modified;
            db.ShopFloorComformance.Update(shopFloor);
            db.SaveChanges();
        }
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
