﻿using corrsDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.IRepositories
{
   public interface IShopFloorComformance
    {
       // Task<ShopFloorComformance> Displaymissedorders(string plantid, int metricid, int week);
       dynamic Displaymissedorders(string plantid, int metricid, int week);
    }
}
