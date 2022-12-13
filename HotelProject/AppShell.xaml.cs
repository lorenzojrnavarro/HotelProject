using HotelProject.View;

namespace HotelProject;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
        Routing.RegisterRoute(nameof(EmployeePage), typeof(EmployeePage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(EmployeeListPage), typeof(EmployeeListPage));
    }
}