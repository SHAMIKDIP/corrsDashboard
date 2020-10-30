using CorrsDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrsDash.ViewModel
{
    public class MetricbasedreasoncodeDetails
    {
        public List<Metricbasedreasoncodeview> MetricreasoncodeviewDetails { get; set; }
        public List<Corrsmetricreasoncodedependency> MetricDetails { get; set; }
        public string reasoncodename {get ; set;}
    }
}
