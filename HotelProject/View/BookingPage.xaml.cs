namespace HotelProject.View;

public partial class BookingPage : ContentPage
{
	public BookingPage(BookingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
		double value = e.NewValue;
        Nights.Text = "Staying " + e.NewValue.ToString() + " Night(s)";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Age.Text = String.Empty;
    }
}