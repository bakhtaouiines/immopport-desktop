using System.Text.Json.Serialization;

namespace immopport_desktop.Type
{
    public class Employee
    {
        [JsonPropertyName("id_agency")]
        public int AgencyId { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; } = string.Empty;

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [JsonPropertyName("mail")]
        public string Mail { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("matricule")]
        public int Matricule { get; set; }
    }
    
    public class EmployeeResponse
    {
        [JsonPropertyName("employee")]
        public Employee? Employee { get; set; }
    }
}
