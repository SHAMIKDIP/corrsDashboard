using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Metricsview
    {
        public string MetricName { get; set; }
        public int? MetricId { get; set; }
        public string TargetCondition { get; set; }
        public string MetricType { get; set; }
        public int? ReasonCodeApplicability { get; set; }
        public string PlantDomain { get; set; }
        public string PlantId { get; set; }
    }
}
