using HotelProject.Services;
using System.ComponentModel;
using HotelProject.Model;
using System.Windows.Input;
using Microsoft.Maui.Networking;
using HotelProject.View;
using CommunityToolkit.Mvvm.Messaging;
using HotelProject.Messages;

namespace HotelProject.ViewModel
{
    public partial class CreateEmployeeViewModel : BaseViewModel
    {
        EmployeeService employeeService;
        IConnectivity connectivity;

        [ObservableProperty]
        public Employee employee = new Employee();

        public CreateEmployeeViewModel(EmployeeService employeeService, CustomerService customerService, IConnectivity connectivity)
        {
            this.employeeService = employeeService;
            this.connectivity = connectivity;
        }

        [RelayCommand]
        async Task CreateEmployee()
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

                employee.IsActive = false;
                employee.IsAdmin = true;

                await employeeService.CreateEmployee(employee, true);

                WeakReferenceMessenger.Default.Send(new RefreshEmployees(employee));                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get rooms: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
