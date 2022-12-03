namespace HotelProject.View;

public partial class UnavailableRoomPage : ContentPage
{
	public UnavailableRoomPage(RoomsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}