namespace HotelProject;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(RoomDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}