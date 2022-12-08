namespace HotelProject.View;

public partial class EmployeeLoginPage : ContentPage
{
    public EmployeeLoginPage(EmployeeLoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}