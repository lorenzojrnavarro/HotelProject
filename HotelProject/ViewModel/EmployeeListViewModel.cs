using CommunityToolkit.Mvvm.Messaging;
using HotelProject.Messages;
using HotelProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.ViewModel
{
    public partial class EmployeeListViewModel : BaseViewModel, IRecipient<RefreshEmployees>
    {        
        public ObservableCollection<Employee> Employees { get; set; } = new();

        EmployeeService employeeService;
        IConnectivity connectivity;

        public EmployeeListViewModel(EmployeeService employeeService, IConnectivity connectivity)
        {
            this.employeeService = employeeService;
            this.connectivity = connectivity;
            Task.Run(async () => await GetEmployeesAsync());
            WeakReferenceMessenger.Default.Register<RefreshEmployees>(this);
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetEmployeesAsync()
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
                var employees = await employeeService.GetEmployees();

                if (Employees.Count != 0)
                    Employees.Clear();

                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }

                Console.WriteLine(Employees);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get rooms: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }


        public void Receive(RefreshEmployees message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {                
                Employees.Add(message.Value);                
            });
        }

        //[RelayCommand]
        //async Task CreateEmployee()
        //{
        //    await Shell.Current.GoToAsync("CreateEmployeePage", true);
        //}
    }
}
