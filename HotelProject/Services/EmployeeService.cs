using System.Net.Http.Json;
using System.Text.Json;
using System.Diagnostics;
using System.Text;

namespace HotelProject.Services;

public class EmployeeService
{
    HttpClient httpClient;
    public EmployeeService()
    {
        this.httpClient = new HttpClient();
    }

    List<Employee> employeeList;
    public async Task<List<Employee>> GetEmployees()
    {
        if (employeeList?.Count > 0)
            return employeeList;

        // Online
        var response = await httpClient.GetAsync("https://localhost:7183/api/Employees");
        if (response.IsSuccessStatusCode)
        {
            employeeList = await response.Content.ReadFromJsonAsync<List<Employee>>();
        }

        // Offline
        //using var stream = await FileSystem.OpenAppPackageFileAsync("employeedata.json");
        //using var reader = new StreamReader(stream);
        //var contents = await reader.ReadToEndAsync();
        //employeeList = JsonSerializer.Deserialize<List<Employee>>(contents);

        return employeeList;
    }

    public async Task CreateEmployee(Employee employee, Boolean isAdmin)
    {
        Uri uri = new Uri(string.Format("https://localhost:7183/api/Employees/" + isAdmin.ToString(), string.Empty));
        // Online
        try
        {
            string json = JsonSerializer.Serialize<Employee>(employee);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await httpClient.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tItem successfully saved.");                
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task PutEmployee(Employee employee, Boolean isAdmin)
    {
        Uri uri = new Uri(string.Format(("https://localhost:7183/api/Employees/" + employee.Id + "%2C%20" + isAdmin.ToString() + "?id=" + employee.Id + "&&IsAdmin" + isAdmin.ToString()), string.Empty));
        // Online
        try
        {
            string json = JsonSerializer.Serialize<Employee>(employee);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await httpClient.PutAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tItem successfully saved.");
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task DeleteEmployee(string employeeId, Boolean isAdmin)
    {
        Uri uri = new Uri(string.Format(("https://localhost:7183/api/Employees/" + employeeId + "%2C%20" + isAdmin.ToString() + "?id=" + employeeId + "&&IsAdmin" + isAdmin.ToString()), string.Empty));
        // Online
        try
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tItem successfully deleted.");
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }
}
