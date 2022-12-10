using HotelProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelProject.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {

        [RelayCommand]
        async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.employeeInfo)))
            {
                Preferences.Remove(nameof(App.employeeInfo));
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
