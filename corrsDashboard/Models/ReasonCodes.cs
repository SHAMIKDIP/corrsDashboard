using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class ReasonCodes
    {
        public ReasonCodes()
        {
            Corrsmetricreasoncodedependency = new HashSet<Corrsmetricreasoncodedependency>();
            ShopFloorComformance = new HashSet<ShopFloorComformance>();
        }

        public string ReasonCode { get; set; }
        public int? Flag { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int ReasonCodeId { get; set; }

        public virtual ICollection<Corrsmetricreasoncodedependency> Corrsmetricreasoncodedependency { get; set; }
        public virtual ICollection<ShopFloorComformance> ShopFloorComformance { get; set; }
        
    }
    public class ReasoncodeList
    {
        public List<ReasonCodes> ReasonCodeList { get; set; }
    }
}
