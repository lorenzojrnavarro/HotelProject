namespace HotelProject.View;

public partial class UnavailableRoomPage : ContentPage
{
	public UnavailableRoomPage(UnavailableRoomsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}