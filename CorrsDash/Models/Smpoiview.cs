using System;
using System.Collections.Generic;

namespace CorrsDash.Models
{
    public partial class Smpoiview
    {
        public string PlantId { get; set; }
        public string PlantCountry { get; set; }
        public string PlantName { get; set; }
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
        public double? QtyTotalStock { get; set; }
        public string BaseUom { get; set; }
        public double? QtyTotalStockAltUom { get; set; }
        public string Aiuom { get; set; }
        public double? UnrestrictedStock { get; set; }
        public double? RestrictedStock { get; set; }
        public double? StockinQualityInspection { get; set; }
        public double? BlockedStock { get; set; }
        public double? ValueLc { get; set; }
        public string Lc { get; set; }
        public double? ValueGc { get; set; }
        public string Gc { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }
        public string Pid { get; set; }
        public string Pname { get; set; }
        public string PlantDomain { get; set; }
    }
}
