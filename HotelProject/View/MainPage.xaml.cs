namespace HotelProject.View;

public partial class MainPage : ContentPage
{
	public MainPage(RoomsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

