using System.Net.Http.Json;
using System.Text.Json;
using System.Diagnostics;
using System.Text;

namespace HotelProject.Services;

public class RoomService
{
    HttpClient httpClient;
    public RoomService()
    {
        this.httpClient = new HttpClient();
    }

    List<Room> roomList;
    public async Task<List<Room>> GetRooms()
    {
        if (roomList?.Count > 0)
            return roomList;

        // Online
        var response = await httpClient.GetAsync("https://webapplication1-sj8.conveyor.cloud/api/Rooms");
        if (response.IsSuccessStatusCode)
        {
            roomList = await response.Content.ReadFromJsonAsync<List<Room>>();
        }

        return roomList;
    }

    public async Task SetAvailability(Room room)
    {
        Uri uri = new Uri(string.Format(("https://webapplication1-sj8.conveyor.cloud/api/Rooms?id=" + room.Id), string.Empty));
        // Online
        try
        {
            string json = JsonSerializer.Serialize<Room>(room);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await httpClient.PutAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tItem successfully saved.");
                await Shell.Current.GoToAsync("../..");
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }
}
