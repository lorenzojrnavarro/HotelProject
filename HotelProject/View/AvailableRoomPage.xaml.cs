namespace HotelProject.View;

public partial class AvailableRoomPage : ContentPage
{
	public AvailableRoomPage(RoomsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}