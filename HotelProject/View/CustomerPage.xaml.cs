namespace HotelProject.View;

public partial class CustomerPage : ContentPage
{
	public CustomerPage(CustomerViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}