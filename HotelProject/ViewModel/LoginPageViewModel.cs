using CommunityToolkit.Mvvm.Messaging;
using HotelProject.Messages;
using HotelProject.Services;

namespace HotelProject.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        public Employee employee = new();
        public List<Employee> Employees { get; set; } = new();

        EmployeeService employeeService;
        IConnectivity connectivity;

        public LoginPageViewModel(EmployeeService employeeService, IConnectivity connectivity)
        {
            this.employeeService = employeeService;
            this.connectivity = connectivity;
            Task.Run(async () => await GetEmployeesAsync());
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetEmployeesAsync()
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
                var employees = await employeeService.GetEmployees();

                if (Employees.Count != 0)
                    Employees.Clear();

                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }

                Console.WriteLine(Employees);

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
        async Task EmployeeLogin()
        {
            Employee searchEmployee = new Employee();
            if(employee.EmployeeId != null)
                searchEmployee = Employees.Find(e => e.EmployeeId == employee.EmployeeId);
            if (searchEmployee != null)
            {
                if (employee.Password == searchEmployee.Password && employee.EmployeeId == searchEmployee.EmployeeId)
                {
                    employee = searchEmployee;
                    employee.IsActive = true;
                    await employeeService.PutEmployee(employee, true);
                    App.employeeInfo= employee;
                    await AppConstant.AddFlyoutMenusDetails();
                }
            }
        }
    }
}
