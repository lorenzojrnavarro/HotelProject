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
}
