namespace HotelProject.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        [RelayCommand]
        async Task OpenEmployeeLogin()
        {
            if (password == "PASSWORD" && email == "email")
                await Shell.Current.GoToAsync("..");
        }
    }
}
