using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HotelProject.Messages
{
    public class RefreshCustomers : ValueChangedMessage<Customer>
    {
        public RefreshCustomers(Customer value) : base(value)
        {
        }
    }
}
