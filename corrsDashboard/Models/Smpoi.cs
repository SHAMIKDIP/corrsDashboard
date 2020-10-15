using System;
using System.Collections.Generic;

namespace corrsDashboard.Models
{
    public partial class Smpoi
    {
        public string Id { get; set; }
        public string PlantId { get; set; }
        public string PlantName { get; set; }
        public string PlantCountry { get; set; }
        public string MrpcontrollerId { get; set; }
        public string MaterialType { get; set; }
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string ProdHierL1product { get; set; }
        public string ProdHierL1productDesc { get; set; }
        public string ProdHierL2brand { get; set; }
        public string ProdHierL2brandDesc { get; set; }
        public string ProdHierL3family { get; set; }
        public string ProdHierL3familyDesc { get; set; }
        public string ProdHierL4subFamily { get; set; }
        public string ProdHierL4subFamilyDesc { get; set; }
        public string StorageLocation { get; set; }
        public string BatchNo { get; set; }
        public string FormLabelExpDate { get; set; }
        public DateTime? AdjustedExpirationDate { get; set; }
        public string InventoryCategorization { get; set; }
        public DateTime? LastMovementDate { get; set; }
        public int? DaysLastMoved { get; set; }
        public string LastMoveType { get; set; }
        public string InventoryStatus { get; set; }
        public string SpecialStockIndicator { get; set; }
        public string Bommaterials { get; set; }
        public string ImpoundPeriod { get; set; }
        public DateTime? ImpoundmentDate { get; set; }
        public string PlantRegion { get; set; }
        public string MtsMto { get; set; }
        public DateTime? Grdate { get; set; }
        public string Vendor { get; set; }
        public string EMCindicator { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string Expiration { get; set; }
        public string ValuationClass { get; set; }
        public int? QtyTotalStock { get; set; }
        public string BaseUom { get; set; }
        public int? QtyTotalStockAltUom { get; set; }
        public string Aiuom { get; set; }
        public int? UnrestrictedStock { get; set; }
        public int? RestrictedStock { get; set; }
        public int? StockinQualityInspection { get; set; }
        public int? BlockedStock { get; set; }
        public int? ValueLc { get; set; }
        public string Lc { get; set; }
        public string ValueGc { get; set; }
        public string Gc { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Corrsplants Plant { get; set; }
    }
}
