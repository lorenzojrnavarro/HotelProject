using HotelProject.Services;
using System.ComponentModel;
using HotelProject.Model;
using System.Windows.Input;
using Microsoft.Maui.Networking;
using HotelProject.View;
using CommunityToolkit.Mvvm.Messaging;
using HotelProject.Messages;

namespace HotelProject.ViewModel;

[QueryProperty(nameof(Room), "Room")]
public partial class BookingPageViewModel : BaseViewModel
{
    RoomService roomService;
    CustomerService customerService;
    IConnectivity connectivity;

    [ObservableProperty]
    public Customer customer = new Customer();

    [ObservableProperty]
    public double nightsStayed;

    [ObservableProperty]
    Room room;

    public BookingPageViewModel(RoomService roomService, CustomerService customerService, IConnectivity connectivity)
    {
        this.roomService = roomService;
        this.customerService = customerService;
        this.connectivity = connectivity;
    }

    [RelayCommand]
    async Task ReserveRoom()
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

            customer.AllowedRoom = room.RoomNumber;
            customer.IdentityProof = "proof";
            customer.PaymentDetails = new PaymentDetails();
            customer.PaymentDetails.PaymentMethod = "Visa";
            customer.PaymentDetails.Amount = (room.Price*nightsStayed).ToString(); 
            customer.IsActive= true;

            await customerService.CreateReservation(customer);

            room.IsActive = false;
            await roomService.SetAvailability(room);

            WeakReferenceMessenger.Default.Send(new RefreshAvailableRooms(room));
            WeakReferenceMessenger.Default.Send(new RefreshUnavailableRooms(room));
            WeakReferenceMessenger.Default.Send(new RefreshCustomers(customer));
            
            await Shell.Current.GoToAsync("../..");            
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get rooms: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }        
    }


    //[ObservableProperty]
    //public DatePicker datePicker = new()
    //{
    //    MinimumDate = DateTime.Today,
    //    MaximumDate = (DateTime.Today.AddMonths(6)),
    //    Date = DateTime.Today,
    //};
}

