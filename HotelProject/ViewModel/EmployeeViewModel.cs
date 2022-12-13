using CommunityToolkit.Mvvm.Messaging;
using HotelProject.View;
using HotelProject.Messages;
using HotelProject.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HotelProject.ViewModel
{
    public partial class EmployeeViewModel : BaseViewModel
    {
        EmployeeService employeeService;
        IConnectivity connectivity;
        [ObservableProperty]
        Employee employee;

        public EmployeeViewModel(EmployeeService employeeService, IConnectivity connectivity)
        {
            this.employeeService = employeeService;
            this.connectivity = connectivity;
            this.employee = App.employeeInfo;
        }

        [RelayCommand]
        async Task SignOut()
        {
            if (App.employeeInfo.IsActive)
            {
                App.employeeInfo.IsActive = false;
                await employeeService.PutEmployee(App.employeeInfo, true);
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}

