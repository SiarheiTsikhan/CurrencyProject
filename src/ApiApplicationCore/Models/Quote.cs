using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplicationCore.Models
{
    public class Quote
    {
        [JsonProperty("start_rate")]
        public decimal StartRate { get; set; }

        [JsonProperty("end_rate")]
        public decimal EndRate { get; set; }

        [JsonProperty("change")]
        public decimal Change { get; set; }

        [JsonProperty("change_pct")]
        public decimal ChangePercentage { get; set; }
    }
}
