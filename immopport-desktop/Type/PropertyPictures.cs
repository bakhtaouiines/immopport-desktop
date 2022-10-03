using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace immopport_desktop.Type
{
    public class PropertyPictures
    {
        [JsonPropertyName("id")]
        public int PropertyPictureId { get; set; }

        [JsonPropertyName("id_property")]
        public int PropertyPictureIdProperty { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; } = string.Empty;

        [JsonPropertyName("path")]
        public string? Path { get; set; } = string.Empty;

        [JsonPropertyName("alt")]
        public string? Alt { get; set; } = string.Empty;

        [JsonPropertyName("order")]
        public int Order { get; set; }
    }
}
