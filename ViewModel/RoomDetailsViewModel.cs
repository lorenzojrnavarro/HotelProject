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

    //public string RoomList
    //{
    //    get 
    //    {
    //        foreach (int i in room.RoomNumber)
    //        {
    //            _displayRoomNumbers += i.ToString() + " ";
    //        }
    //        return _displayRoomNumbers;
    //    }
    //}

    //[RelayCommand]
    //async Task OpenMap()
    //{
    //    try
    //    {
    //        await map.OpenAsync(Room.Latitude, Room.Longitude, new MapLaunchOptions
    //        {
    //            Name = Room.Name,
    //            NavigationMode = NavigationMode.None
    //        });
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Unable to launch maps: {ex.Message}");
    //        await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
    //    }
    //}
}
