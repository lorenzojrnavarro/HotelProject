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
		builder.Logging.AddDebug();
#endif

    	builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IMap>(Map.Default);
		
		builder.Services.AddSingleton<RoomService>();
		builder.Services.AddSingleton<RoomsViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<RoomDetailsViewModel>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
