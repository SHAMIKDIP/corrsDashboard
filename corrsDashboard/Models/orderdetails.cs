using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.Models
{
    public class orderdetails
    {
        [JsonProperty("plantid")]
        public string plantid { get; set; }

        [JsonProperty("metricid")]
        public int metricid { get; set; }
        [JsonProperty("week")]
        public int week { get; set; }
    }
}
