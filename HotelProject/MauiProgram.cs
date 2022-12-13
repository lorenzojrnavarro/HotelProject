using Microsoft.Extensions.Logging;
using HotelProject.Services;
using HotelProject.View;

namespace HotelProject;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

#if DEBUG
        builder.Logging.ClearProviders();
#endif

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        //Services
        builder.Services.AddSingleton<RoomService>();
        builder.Services.AddSingleton<CustomerService>();
        builder.Services.AddSingleton<EmployeeService>();

        //ViewModels
        builder.Services.AddSingleton<RoomsViewModel>();
        builder.Services.AddSingleton<UnavailableRoomsViewModel>();
        builder.Services.AddSingleton<CustomerViewModel>();
        builder.Services.AddTransient<RoomDetailsViewModel>();
        builder.Services.AddTransient<BookingViewModel>();
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<EmployeeListViewModel>();
        builder.Services.AddTransient<EmployeeViewModel>();
        builder.Services.AddTransient<CreateEmployeeViewModel>();

        //Views
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AvailableRoomPage>();
        builder.Services.AddSingleton<UnavailableRoomPage>();
        builder.Services.AddSingleton<CustomerPage>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<BookingPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<EmployeePage>();
        builder.Services.AddTransient<EmployeeListPage>();
        builder.Services.AddTransient<CreateEmployeePage>();

        return builder.Build();
    }
}
