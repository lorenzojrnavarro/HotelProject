using HotelProject.Services;
using HotelProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelProject.ViewModel
{
    public partial class AppShellViewModel : BaseViewModel
    {
        EmployeeService employeeService;
        IConnectivity connectivity;

        public AppShellViewModel(EmployeeService employeeService, IConnectivity connectivity)
        {
            this.employeeService = employeeService;
            this.connectivity = connectivity;
        }

        [RelayCommand]
        async Task SignOut()
        {
            EmployeeService employeeService = new EmployeeService();
            if (App.employeeInfo.IsActive)
            {
                App.employeeInfo.IsActive = false;
                await employeeService.PutEmployee(App.employeeInfo, true);
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
