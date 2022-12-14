using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using HotelProject.Messages;
using HotelProject.Services;

namespace HotelProject.ViewModel;

public partial class UnavailableRoomsViewModel : BaseViewModel, IRecipient<RefreshUnavailableRooms>
{
    public ObservableCollection<Room> Rooms { get; set; } = new();
    RoomService roomService;
    IConnectivity connectivity;

    
    public UnavailableRoomsViewModel(RoomService roomService, IConnectivity connectivity)
    {
        Title = "Room Finder";
        this.roomService = roomService;
        this.connectivity = connectivity;
        Task.Run(async () => await GetUnavailableRoomsAsync());

        WeakReferenceMessenger.Default.Register<RefreshUnavailableRooms>(this);
    }
    

    [ObservableProperty]
    bool isRefreshing;

    void Refresh()
    {
        Task.Run(async () => await GetUnavailableRoomsAsync());
    }

    [RelayCommand]
 
    async Task GetUnavailableRoomsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }

            IsBusy = true;
            var rooms = await roomService.GetRooms();

            if (Rooms.Count != 0)
                Rooms.Clear();

            foreach (var room in rooms)
            {
                if (!room.IsActive)
                    Rooms.Add(room);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get rooms: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

    [RelayCommand]
    async Task GoToDetails(Room room)
    {
        if (room == null)
        return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Room", room }
        });
    }

    public void Receive(RefreshUnavailableRooms message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (!message.Value.IsActive)
            {
                Rooms.Add(message.Value);
            }
            if (message.Value.IsActive)
            {
                Rooms.Remove(Rooms.Where(i => i.Id == message.Value.Id).Single());
            }
        });
    }
}
