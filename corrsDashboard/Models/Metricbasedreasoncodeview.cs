using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Metricbasedreasoncodeview
    {
        public string ReasonCode { get; set; }
        public int? ReasonCodeId { get; set; }
        public int? Flag { get; set; }
        public int? MetricId { get; set; }
        public string MetricName { get; set; }
    }
}
