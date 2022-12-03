using HotelProject.Services;

namespace HotelProject.ViewModel;

public partial class UnavailableRoomsViewModel : BaseViewModel
{
    public ObservableCollection<Room> Rooms { get; } = new();
    RoomService roomService;
    IConnectivity connectivity;
    public UnavailableRoomsViewModel(RoomService roomService, IConnectivity connectivity)
    {
        Title = "Room Finder";
        this.roomService = roomService;
        this.connectivity = connectivity;
        Task.Run(async () => await GetUnRoomsAsync());
    }

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
 
    async Task GetUnRoomsAsync()
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
            var rooms = await roomService.GetUnRooms();

            if (Rooms.Count != 0)
                Rooms.Clear();

            foreach (var room in rooms)
                Rooms.Add(room);

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
}
