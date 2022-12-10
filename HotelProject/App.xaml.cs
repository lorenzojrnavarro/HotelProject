using HotelProject.View;

namespace HotelProject;

public partial class App : Application
{
	public static Employee employeeInfo;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
