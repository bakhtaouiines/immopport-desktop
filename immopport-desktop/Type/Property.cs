using System.Text.Json.Serialization;

namespace immopport_desktop.Type
{
    public class Property
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("addition_address")]
        public string? AdditionAddress { get; set; } = string.Empty;

        [JsonPropertyName("zipcode")]
        public int Zipcode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("surface")]
        public int? Surface { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; } = string.Empty;

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; } = string.Empty;

        [JsonPropertyName("id_employee")]
        public int IdEmployee { get; set; }

        [JsonPropertyName("matricule")]
        public int Matricule { get; set; }

        [JsonPropertyName("is_furnished")]
        public bool IsFurnished { get; }

        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; }

        [JsonPropertyName("is_prospect")]
        public bool IsProspect { get; }

        [JsonPropertyName("rooms")]
        public Room[]? Rooms { get; set; }

        [JsonPropertyName("property_pictures")]
        public PropertyPictures[]? PropertyPictures { get; set; }

        [JsonPropertyName("features_lists")]
        public FeaturesList[]? FeaturesList { get; set; }

        [JsonPropertyName("property_types")]
        public PropertyType? PropertyType { get; set; }

        [JsonPropertyName("property_transaction_type")]
        public PropertyTransactionType? PropertyTransactionType { get; set; }

        [JsonPropertyName("property_categories")]
        public PropertyCategory? PropertyCategory { get; set; }

        [JsonPropertyName("heater")]
        public Heater? Heater { get; set; }

        [JsonPropertyName("kitchen")]
        public Kitchen? Kitchen { get; set; }

        public string AgentInfo
        {
            get
            {
                return Firstname + " " + Lastname + " -" + Matricule;
            }
        }
    }

    public class PropertyList
    {
        [JsonPropertyName("property")]
        public Property[] ? Property { get; set; }
    }

    public class PropertyResponse
    {
        [JsonPropertyName("property")]
        public Property? Property { get; set; }
    }
}
