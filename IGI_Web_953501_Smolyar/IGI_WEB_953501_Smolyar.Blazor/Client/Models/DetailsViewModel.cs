using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IGI_WEB_953501_Smolyar.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("cost")]
        public float Cost { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
