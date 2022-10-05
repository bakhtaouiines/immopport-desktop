using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace immopport_desktop.Type
{
    public class Room
    {
        [JsonPropertyName("id")]
        public int RoomId { get; set; }

        [JsonPropertyName("id_property")]
        public int PropertyId { get; set; }

        [JsonPropertyName("id_room_type")]
        public int RoomTypeId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
