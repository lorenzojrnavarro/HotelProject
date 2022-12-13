namespace HotelProject.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

        if (App.employeeInfo != null)
        {
            lblUserName.Text = App.employeeInfo.Name;
            lblUserId.Text = App.employeeInfo.EmployeeId;
            if(App.employeeInfo.IsAdmin)
                lblUserRole.Text = "Admin";
            else
            {
                lblUserRole.Text = string.Empty;
            }
        }
    }
}