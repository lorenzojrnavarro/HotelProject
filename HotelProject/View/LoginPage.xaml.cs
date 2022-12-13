namespace HotelProject.View;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        EmployeeId.Text = String.Empty;
        Password.Text = String.Empty;
    }
}