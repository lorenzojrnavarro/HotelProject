namespace HotelProject.View;

public partial class BookingPage : ContentPage
{
	public BookingPage(BookingPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
		double value = e.NewValue;
        Nights.Text = "Staying " + e.NewValue.ToString() + " Night(s)";
    }
}