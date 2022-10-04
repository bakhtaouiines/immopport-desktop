using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace immopport_desktop.Type
{
    public class PropertyCategory
    {
        [JsonPropertyName("id")]
        public int PropertyCategoryId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
