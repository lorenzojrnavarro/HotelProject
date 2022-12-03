namespace HotelProject.Model;

public class Room
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string RoomDescription { get; set; }
    public string Image { get; set; }
    public int RoomNumber { get; set; }
    public double Price { get; set; }
    public Boolean IsActive { get; set; }
}