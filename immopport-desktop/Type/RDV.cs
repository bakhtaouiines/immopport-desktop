using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace immopport_desktop.Type
{
    public class RDV
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("id_property")]
        public int PropertyId { get; set; }

        [JsonPropertyName("id_client")]
        public int CustomerId { get; set; }

        [JsonPropertyName("id_label")]
        public int LabelId { get; set; }

        [JsonPropertyName("id_employee")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; } = string.Empty;

        [JsonPropertyName("beginning")]
        public string? Beginning { get; set; } = string.Empty;

        [JsonPropertyName("end")]
        public string? End { get; set; } = string.Empty;

        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; } = string.Empty;

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonPropertyName("mail")]
        public string Mail { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("employeeLastname")]
        public string EmployeeLastname { get; set; } = string.Empty;

        [JsonPropertyName("employeeFirstname")]
        public string EmployeeFirstname { get; set; } = string.Empty;

        [JsonPropertyName("matricule")]
        public string Matricule { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("zipcode")]
        public int Zipcode { get; set; }

        [JsonPropertyName("is_visit")]
        public bool IsVisit { get; set; } = false;

        [JsonPropertyName("name")]
        public string AgencyName { get; set; } = string.Empty;
    }

    public class RDVList
    {
        [JsonPropertyName("rdv")]
        public RDV[]? RDV { get; set; }
    }
}
}
