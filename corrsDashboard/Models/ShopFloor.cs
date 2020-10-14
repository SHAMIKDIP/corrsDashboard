using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.Models
{
    public class ShopFloor
    {
        [JsonProperty("processOrder")]
        public long ProcessOrder { get; set; }

        [JsonProperty("Resource")]
        public string Resource { get; set; }
        [JsonProperty("Flag")]
        public string Flag { get; set; }
        [JsonProperty("ReasonCodeId")]
        public int? ReasonCodeId { get; set; }
        [JsonProperty("metricid")]
        public int metricid { get; set; }

    }
}
