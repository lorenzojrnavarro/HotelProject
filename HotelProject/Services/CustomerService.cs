using System.Net.Http.Json;
using System.Text.Json;
using System.Diagnostics;
using System.Text;

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
        var response = await httpClient.GetAsync("https://localhost:7183/api/Customers");
        if (response.IsSuccessStatusCode)
        {
            customerList = await response.Content.ReadFromJsonAsync<List<Customer>>();
        }

        // Offline
        //using var stream = await FileSystem.OpenAppPackageFileAsync("customerdata.json");
        //using var reader = new StreamReader(stream);
        //var contents = await reader.ReadToEndAsync();
        //customerList = JsonSerializer.Deserialize<List<Customer>>(contents);

        return customerList;
    }

    public async Task CreateReservation(Customer customer)
    {
        Uri uri = new Uri(string.Format("https://localhost:7183/api/Customers", string.Empty));
        // Online
        try
        {
            string json = JsonSerializer.Serialize<Customer>(customer);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await httpClient.PostAsync(uri, content);
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
