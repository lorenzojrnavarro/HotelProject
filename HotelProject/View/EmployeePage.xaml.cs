namespace HotelProject.View;

public partial class EmployeePage : ContentPage
{
	public EmployeePage(EmployeeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}