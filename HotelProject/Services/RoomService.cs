﻿using System.Net.Http.Json;

namespace HotelProject.Services;

public class RoomService
{
    HttpClient httpClient;
    public RoomService()
    {
        this.httpClient = new HttpClient();
    }

    List<Room> roomList;
    List<Room> UnroomList;
    public async Task<List<Room>> GetRooms()
    {
        if (roomList?.Count > 0)
            return roomList;

        // Online
        /*var response = await httpClient.GetAsync("https://www.montemagno.com/rooms.json");
        if (response.IsSuccessStatusCode)
        {
            roomList = await response.Content.ReadFromJsonAsync<List<Room>>();
        }*/

        // Offline
        using var stream = await FileSystem.OpenAppPackageFileAsync("roomdata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        roomList = JsonSerializer.Deserialize<List<Room>>(contents);

        return roomList;
    }
    public async Task<List<Room>> GetUnRooms()
    {
        if (UnroomList?.Count > 0)
            return UnroomList;

        // Online
        /*var response = await httpClient.GetAsync("https://www.montemagno.com/rooms.json");
        if (response.IsSuccessStatusCode)
        {
            roomList = await response.Content.ReadFromJsonAsync<List<Room>>();
        }*/

        // Offline
        using var stream = await FileSystem.OpenAppPackageFileAsync("Uroomdata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        UnroomList = JsonSerializer.Deserialize<List<Room>>(contents);

        return UnroomList;
    }
}
