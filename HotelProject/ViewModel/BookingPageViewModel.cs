using HotelProject.Services;
using System.ComponentModel;

namespace HotelProject.ViewModel;

[QueryProperty(nameof(Room), "Room")]
public partial class BookingPageViewModel : BaseViewModel
{
    IMap map;
    public BookingPageViewModel(IMap map)
    {
        this.map = map;
    }

    [ObservableProperty]
    Room room;

    //[ObservableProperty]
    //public DatePicker datePicker = new()
    //{
    //    MinimumDate = DateTime.Today,
    //    MaximumDate = (DateTime.Today.AddMonths(6)),
    //    Date = DateTime.Today,
    //};
}

