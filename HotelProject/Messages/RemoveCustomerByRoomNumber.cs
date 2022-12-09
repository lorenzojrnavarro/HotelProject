using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HotelProject.Messages
{
    public class RemoveCustomerByRoomNumber : ValueChangedMessage<Room>
    {
        public RemoveCustomerByRoomNumber(Room value) : base(value)
        {
        }
    }
}
