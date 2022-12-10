namespace HotelProject.View;

public partial class EmployeePage : ContentPage
{
	public EmployeePage(EmployeePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}