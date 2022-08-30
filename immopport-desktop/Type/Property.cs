using System.Text.Json.Serialization;

namespace immopport_desktop.Type
{
    public class Property
    {

        [JsonPropertyName("id")]
        public int PropertyId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string? Address { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public int Price { get; set; }
    }

    public class PropertyResponse
    {
        [JsonPropertyName("property")]
        public Property[]? Property { get; set; }
    }
}
