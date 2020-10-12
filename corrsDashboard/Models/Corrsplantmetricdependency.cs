using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Corrsplantmetricdependency
    {
        public string PlantDomain { get; set; }
        public int? MetricCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Corrsmetrics MetricCodeNavigation { get; set; }
        public virtual Corrsplantdomains PlantDomainNavigation { get; set; }
    }
}
