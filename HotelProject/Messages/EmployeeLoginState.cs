using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HotelProject.Messages
{
    public class EmployeeLoginState : ValueChangedMessage<Employee>
    {
        public EmployeeLoginState(Employee value) : base(value)
        {
        }
    }
}
