using HotelProject.View;

namespace HotelProject.ViewModel;

[QueryProperty(nameof(Room), "Room")]
public partial class RoomDetailsViewModel : BaseViewModel
{
    IMap map;
    public RoomDetailsViewModel(IMap map)
    {
        this.map = map;
    }

    [ObservableProperty]
    Room room;

    [RelayCommand]
    async Task OpenReservationPage()
    {
        await Shell.Current.GoToAsync("BookingPage", true, new Dictionary<string, object>
        {
            {"Room", room }
        });
    }

}
