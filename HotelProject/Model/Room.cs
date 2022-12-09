using System.Text.Json.Serialization;

namespace HotelProject.Model;

public class Room
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("roomDescription")]
    public string RoomDescription { get; set; }
    [JsonPropertyName("image")]
    public string Image { get; set; }
    [JsonPropertyName("roomNumber")]
    public int RoomNumber { get; set; }
    [JsonPropertyName("price")]
    public double Price { get; set; }
    [JsonPropertyName("isActive")]
    public Boolean IsActive { get; set; }
}