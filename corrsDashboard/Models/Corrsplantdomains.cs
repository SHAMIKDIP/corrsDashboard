using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Corrsplantdomains
    {
        public Corrsplantdomains()
        {
            Corrsplants = new HashSet<Corrsplants>();
        }

        public int DomainId { get; set; }
        public string DomainCode { get; set; }

        public virtual ICollection<Corrsplants> Corrsplants { get; set; }
    }
}
