using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace immopport_desktop.Type
{
    public class RoomType
    {
        [JsonPropertyName("id")]
        public int RoomTypeId { get; set; }

        [JsonPropertyName("name")]
        public string RoomTypeName { get; set; } = string.Empty;
    }
}
