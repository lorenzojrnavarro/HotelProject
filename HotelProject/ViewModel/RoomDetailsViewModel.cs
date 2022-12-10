using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Maui.Markup;
using HotelProject.Services;
using HotelProject.View;
using Microsoft.Maui.Networking;
using CommunityToolkit.Mvvm.Messaging;
using HotelProject.Messages;

namespace HotelProject.ViewModel;

[QueryProperty(nameof(Room), "Room")]
public partial class RoomDetailsViewModel : BaseViewModel
{
    IConnectivity connectivity;
    RoomService roomService;

    [ObservableProperty]
    Boolean isUnavailable;
    public RoomDetailsViewModel(RoomService roomService, IConnectivity connectivity)
    {
        this.roomService = roomService;
        this.connectivity = connectivity;
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

    [RelayCommand]
    async Task CheckOutCustomer()
    {
        room.IsActive = true;
        await roomService.SetAvailability(room);
        
        WeakReferenceMessenger.Default.Send(new RemoveCustomerByRoomNumber(room));        
        WeakReferenceMessenger.Default.Send(new RefreshAvailableRooms(room));
        WeakReferenceMessenger.Default.Send(new RefreshUnavailableRooms(room));
        await Shell.Current.GoToAsync("..");
    }


}
