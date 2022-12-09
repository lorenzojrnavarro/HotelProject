using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HotelProject.Messages
{
    public class RefreshUnavailableRooms : ValueChangedMessage<Room>
    {
        public RefreshUnavailableRooms(Room value) : base(value)
        {
        }
    }
}
