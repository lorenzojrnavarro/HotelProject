﻿using CommunityToolkit.Mvvm.Messaging;
using HotelProject.Messages;
using HotelProject.Services;

namespace HotelProject.ViewModel;

public partial class CustomerViewModel : BaseViewModel, IRecipient<RefreshCustomers>
{
    public ObservableCollection<Customer> Customers { get; set; } = new();
    [ObservableProperty]
    Employee currentEmployee = new();

    CustomerService customerService;
    IConnectivity connectivity;
    public CustomerViewModel(CustomerService customerService, IConnectivity connectivity)
    {
        Title = "Customer";
        this.customerService = customerService;
        this.connectivity = connectivity;

        WeakReferenceMessenger.Default.Register<EmployeeLoginState>(this, (sender, employeeMessage) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                currentEmployee = employeeMessage.Value;
                Task.Run(async () => await GetCustomersAsync());
            });
        });        

        WeakReferenceMessenger.Default.Register<RemoveCustomerByRoomNumber>(this, (sender, message) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                RemoveCustomer(message.Value);
            });
        });

        WeakReferenceMessenger.Default.Register<RefreshCustomers>(this);
        
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

    public async void RemoveCustomer(Room message)
    {
        Customer customer = Customers.Where(customer => customer.AllowedRoom == message.RoomNumber).Single();
        if (customer != null)
        {
            customer.IsActive= false;
            WeakReferenceMessenger.Default.Send(new RefreshCustomers(customer));
            await customerService.DeleteCustomer(customer.Id);
        }
    }

    public void Receive(RefreshCustomers message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (message.Value.IsActive)
            {
                Customers.Add(message.Value);
            }
            if (!message.Value.IsActive)
            {
                Customer customer = Customers.Where(customer => customer == message.Value).Single();
                Customers.Remove(customer);
            }
        });
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
