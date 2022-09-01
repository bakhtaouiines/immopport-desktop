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

        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; } = string.Empty;

        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; } = string.Empty;

        [JsonPropertyName("id_employee")]
        public int IdEmployee { get; set; }

        public string FisrtLasname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }



    }

    public class PropertyResponse
    {
        [JsonPropertyName("property")]
        public Property[] ? Property { get; set; }
    }
}
