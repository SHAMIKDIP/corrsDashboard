using System;
using System.Collections.Generic;

namespace CorrsDash.Models
{
    public partial class ShopFloorComformance
    {
        public string Resource { get; set; }
        public string ResourceName { get; set; }
        public int? PhaseId { get; set; }
        public string PlantName { get; set; }
        public string PlantId { get; set; }
        public string MrpcontrollerId { get; set; }
        public string MrpcontrollerName { get; set; }
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string BatchId { get; set; }
        public int? OrderQuantity { get; set; }
        public string OrderQuantityUnit { get; set; }
        public DateTime? FinishDateScheduled { get; set; }
        public DateTime? FinishDateConfirmed { get; set; }
        public int? DiffInDays { get; set; }
        public string Flag { get; set; }
        public int? Week { get; set; }
        public int? Year { get; set; }
        public long ProcessOrder { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? Month { get; set; }
        public string Quarter { get; set; }
        public int? ReasonCodeId { get; set; }
        public int? ReasonCornerFlag { get; set; }

        public virtual Corrsplants Plant { get; set; }
        public virtual ReasonCodes ReasonCode { get; set; }
    }
}
