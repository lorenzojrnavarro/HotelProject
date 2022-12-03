using HotelProject.Services;

namespace HotelProject.ViewModel;

public partial class CustomerViewModel : BaseViewModel
{
    public ObservableCollection<Customer> Customers { get; } = new();
    CustomerService customerService;
    IConnectivity connectivity;
    public CustomerViewModel(CustomerService customerService, IConnectivity connectivity)
    {
        Title = "Customer Finder";
        this.customerService = customerService;
        this.connectivity = connectivity;
        Task.Run(async () => await GetCustomersAsync());
    }

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
 
    async Task GetCustomersAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }

            IsBusy = true;
            var customers = await customerService.GetCustomers();

            if (Customers.Count != 0)
                Customers.Clear();

            foreach (var customer in customers)
                Customers.Add(customer);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get customers: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

    //[RelayCommand]
    //async Task GoToDetails(Customer customer)
    //{
    //    if (customer == null)
    //    return;

    //    await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
    //    {
    //        {"Customer", customer }
    //    });
    //}
}
