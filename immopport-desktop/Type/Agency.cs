using System.Text.Json.Serialization;

namespace immopport_desktop.Type
{
    public class Agency
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("zipcode")]
        public int Zipcode { get; set; }

        [JsonPropertyName("mail")]
        public string Mail { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;        
    }

    public class AgenciesList
    {
        [JsonPropertyName("agency")]
        public Agency[]? Agency { get; set; }
    }
}
