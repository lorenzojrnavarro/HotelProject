using System.Net.Http.Json;

namespace HotelProject.Services;

public class CustomerService
{
    HttpClient httpClient;
    public CustomerService()
    {
        this.httpClient = new HttpClient();
    }

    List<Customer> customerList;
    public async Task<List<Customer>> GetCustomers()
    {
        if (customerList?.Count > 0)
            return customerList;

        // Online
        /*var response = await httpClient.GetAsync("https://www.montemagno.com/rooms.json");
        if (response.IsSuccessStatusCode)
        {
            roomList = await response.Content.ReadFromJsonAsync<List<Room>>();
        }*/

        // Offline
        using var stream = await FileSystem.OpenAppPackageFileAsync("customerdata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        customerList = JsonSerializer.Deserialize<List<Customer>>(contents);

        return customerList;
    }
}
