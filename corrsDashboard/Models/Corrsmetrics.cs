using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Corrsmetrics
    {
        public Corrsmetrics()
        {
            Configurationmaster = new HashSet<Configurationmaster>();
            Corrsmetricreasoncodedependency = new HashSet<Corrsmetricreasoncodedependency>();
            Corrsplantmetricdependency = new HashSet<Corrsplantmetricdependency>();
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
        public virtual ICollection<Corrsmetricreasoncodedependency> Corrsmetricreasoncodedependency { get; set; }
        public virtual ICollection<Corrsplantmetricdependency> Corrsplantmetricdependency { get; set; }
    }
}
