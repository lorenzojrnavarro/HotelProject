using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HotelProject.Messages
{
    public class RefreshEmployees : ValueChangedMessage<Employee>
    {
        public RefreshEmployees(Employee value) : base(value)
        {
        }
    }
}
