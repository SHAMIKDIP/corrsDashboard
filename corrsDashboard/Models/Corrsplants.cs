using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Corrsplants
    {
        public Corrsplants()
        {
            ShopFloorComformance = new HashSet<ShopFloorComformance>();
            Smpoi = new HashSet<Smpoi>();
        }

        public string PlantId { get; set; }
        public string PlantName { get; set; }
        public string PlantDomain { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? Flag { get; set; }

        public virtual Corrsplantdomains PlantDomainNavigation { get; set; }
        public virtual ICollection<ShopFloorComformance> ShopFloorComformance { get; set; }
        public virtual ICollection<Smpoi> Smpoi { get; set; }
    }
}
