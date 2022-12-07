using HotelProject.Services;
using System.ComponentModel;
using HotelProject.Model;
using System.Windows.Input;
using Microsoft.Maui.Networking;

namespace HotelProject.ViewModel;

[QueryProperty(nameof(Room), "Room")]
public partial class BookingPageViewModel : BaseViewModel, INotifyPropertyChanged
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

            customer.allowedRoom = room.RoomNumber;
            customer.identityProof = "proof";
            customer.paymentDetails = new PaymentDetails();
            customer.paymentDetails.paymentMethod = "Visa";
            customer.paymentDetails.amount = (room.Price*nightsStayed).ToString(); 
            customer.isActive= true;

            await customerService.CreateReservation(customer);
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

    public ICommand CustomerReservation { get; private set; }
    


    //[ObservableProperty]
    //public DatePicker datePicker = new()
    //{
    //    MinimumDate = DateTime.Today,
    //    MaximumDate = (DateTime.Today.AddMonths(6)),
    //    Date = DateTime.Today,
    //};
}

