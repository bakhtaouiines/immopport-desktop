using System.Text.Json.Serialization;

namespace immopport_desktop.Type
{
    public class Customer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; } = string.Empty;

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonPropertyName("mail")]
        public string Mail { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class CustomerList
    {
        [JsonPropertyName("client")]
        public Customer[]? Customer { get; set; }
    }

    public class CustomerResponse
    {
        [JsonPropertyName("client")]
        public Customer? Customer { get; set; }
    }
}
