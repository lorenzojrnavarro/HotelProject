namespace HotelProject.View;

public partial class EmployeeListPage : ContentPage
{
    public EmployeeListPage(EmployeeListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}