﻿using CorrsDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrsDash.IRepositories
{
    public interface IAddreasoncode
    {
        Task<List<Metricbasedreasoncodeview>> Getallreasoncode();
        void AddReasonCodes(ReasonCodes reasonCodes, int metricId, int Flag);
    }
}
