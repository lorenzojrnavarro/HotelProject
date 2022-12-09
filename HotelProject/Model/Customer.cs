using System.Text.Json.Serialization;

namespace HotelProject.Model;

public class Customer
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("gender")]
    public string Gender { get; set; }
    [JsonPropertyName("age")]
    public int Age { get; set; }
    [JsonPropertyName("allowedRoom")]
    public int AllowedRoom { get; set; }
    [JsonPropertyName("identityProof")]
    public string IdentityProof { get; set; }
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
    [JsonPropertyName("paymentDetails")]
    public PaymentDetails PaymentDetails { get; set; }
    [JsonPropertyName("isActive")]
    public Boolean IsActive { get; set; }

}

public class PaymentDetails
{
    [JsonPropertyName("paymentMethod")]
    public string PaymentMethod { get; set; }
    [JsonPropertyName("amount")]
    public string Amount { get; set; }
}



