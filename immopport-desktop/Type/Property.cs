using System.Text.Json.Serialization;

namespace immopport_desktop.Type
{
    public class Property
    {

        [JsonPropertyName("id")]
        public int PropertyId { get; set; }

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

        [JsonPropertyName("room_types")]
        public RoomType[]? RoomType { get; set; }

        [JsonPropertyName("features_lists")]
        public FeaturesList[]? FeaturesList { get; set; }

        public string AgentInfo
        {
            get
            {
                return Firstname + " " + Lastname + " -" + Matricule;
            }
        }
    }

    public class PropertyCategories
    {
        [JsonPropertyName("property_categories")]
        public Property[]? PropertyCategory { get; set; }
    }

    /*    public class PropertyTypes
        {
            [JsonPropertyName("property_types")]
            public Property[]? PropertyType { get; set; }
        }

        public class EnergyAudits
        {
            [JsonPropertyName("energy_audits")]
            public Property[]? EnergyAudit { get; set; }
        }

        public class Kitchen
        {
            [JsonPropertyName("kitchen")]
            public Property[]? PropertyKitchen { get; set; }
        }

        public class Heater
        {
            [JsonPropertyName("heater")]
            public Property[]? PropertyHeater { get; set; }
        }
    */
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
