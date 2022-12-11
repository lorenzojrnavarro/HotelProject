namespace HotelProject.View;

public partial class CreateEmployeePage : ContentPage
{
	public CreateEmployeePage(CreateEmployeeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		Name.Text =	string.Empty;
		EmpEmail.Text = string.Empty;
		EmployeeId.Text = string.Empty;
		EmployeePassword.Text = string.Empty;
		Gender.Text = string.Empty;
		Age.Text = string.Empty;
		Salary.Text = string.Empty;
		Phone.Text = string.Empty;
		Address.Text = string.Empty;

    }
}