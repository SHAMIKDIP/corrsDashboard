using System;
using System.Collections.Generic;

namespace CorrsDash.Models
{
    public partial class Corrsplantdomains
    {
        public Corrsplantdomains()
        {
            Corrsplantmetricdependency = new HashSet<Corrsplantmetricdependency>();
            Corrsplants = new HashSet<Corrsplants>();
        }

        public int DomainId { get; set; }
        public string DomainCode { get; set; }

        public virtual ICollection<Corrsplantmetricdependency> Corrsplantmetricdependency { get; set; }
        public virtual ICollection<Corrsplants> Corrsplants { get; set; }
    }
}
