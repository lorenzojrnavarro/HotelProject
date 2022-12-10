namespace HotelProject.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

        if (App.employeeInfo != null)
        {
            lblUserName.Text = App.employeeInfo.Name;
            lblUserEmail.Text = App.employeeInfo.Email;
            if(App.employeeInfo.IsAdmin)
                lblUserRole.Text = "Admin";
        }
    }
}