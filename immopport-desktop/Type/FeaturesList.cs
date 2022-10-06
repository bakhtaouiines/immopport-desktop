using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace immopport_desktop.Type
{
    public class FeaturesList
    {
        [JsonPropertyName("id")]
        public int FeaturesListId { get; set; }

        [JsonPropertyName("id_feature")]
        public int FeatureId { get; set; }

        [JsonPropertyName("id_property")]
        public int PropertyId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
