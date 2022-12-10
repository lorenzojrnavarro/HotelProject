using System.Text.Json.Serialization;

namespace HotelProject.Model
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("employeeId")]
        public string EmployeeId { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("salary")]
        public double Salary { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
            
        [JsonPropertyName("isActive")]
        public Boolean IsActive { get; set; }

        [JsonPropertyName("isAdmin")]
        public Boolean IsAdmin { get; set; }
    }
}
