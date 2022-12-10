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
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<RoomService>();
        builder.Services.AddSingleton<CustomerService>();
        builder.Services.AddSingleton<EmployeeService>();

        builder.Services.AddSingleton<RoomsViewModel>();
        builder.Services.AddSingleton<UnavailableRoomsViewModel>();
        builder.Services.AddSingleton<CustomerViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AvailableRoomPage>();
        builder.Services.AddSingleton<UnavailableRoomPage>();
        builder.Services.AddSingleton<CustomerPage>();


        builder.Services.AddTransient<RoomDetailsViewModel>();
        builder.Services.AddTransient<DetailsPage>();

        builder.Services.AddTransient<BookingPage>();
        builder.Services.AddTransient<BookingPageViewModel>();

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginPageViewModel>();

        return builder.Build();
    }
}
