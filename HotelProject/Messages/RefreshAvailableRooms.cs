using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HotelProject.Messages
{
    public class RefreshAvailableRooms : ValueChangedMessage<Room>
    {
        public RefreshAvailableRooms(Room value) : base(value)
        {
        }
    }
}
