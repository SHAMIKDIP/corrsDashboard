using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrsDash.ViewModel
{
    public class CorrsplantsViewModel
    {
        public string PlantId { get; set; }
        public string PlantName { get; set; }
        public string PlantDomain { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
