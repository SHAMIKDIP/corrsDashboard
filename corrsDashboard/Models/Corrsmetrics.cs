using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Corrsmetrics
    {
        public Corrsmetrics()
        {
            Configurationmaster = new HashSet<Configurationmaster>();
        }

        public int MetricId { get; set; }
        public string MetricName { get; set; }
        public string TargetCondition { get; set; }
        public string MetricType { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Configurationmaster> Configurationmaster { get; set; }
    }
}
