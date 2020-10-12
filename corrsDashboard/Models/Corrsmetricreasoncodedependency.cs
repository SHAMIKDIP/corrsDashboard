using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Corrsmetricreasoncodedependency
    {
        public int MetricId { get; set; }
        public int ReasonId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Corrsmetrics Metric { get; set; }
        public virtual ReasonCodes Reason { get; set; }
    }
}
