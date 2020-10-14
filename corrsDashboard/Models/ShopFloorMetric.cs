using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.Models
{
    public class ShopFloorMetric
    {
        [JsonProperty("Resource")]
        public string Resource { get; set; }

        [JsonProperty("MetricId")]
        public int MetricId { get; set; }

        [JsonProperty("Flag")]
        public string Flag { get; set; }

        [JsonProperty("ProcessOrder")]
        public long ProcessOrder { get; set; }

        [JsonProperty("ReasonCodeId")]
        public int? ReasonCodeId { get; set; }
    }
    public class ShopFloorMetricDetails
    {
        public List<ShopFloorMetric> shopFloorMetricDetails { get; set; }
    }
}
