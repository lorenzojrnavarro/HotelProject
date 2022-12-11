using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.View;
using HotelProject.Controls;


namespace HotelProject.Model
{
    class AppConstant
    {
        public async static Task AddFlyoutMenusDetails()
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

            var employeeDashboardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(EmployeePage)).FirstOrDefault();
            if (employeeDashboardInfo != null) AppShell.Current.Items.Remove(employeeDashboardInfo);

            if(App.employeeInfo.IsActive)
            {

                var flyoutItem = new FlyoutItem()
                {
                    Route = nameof(EmployeePage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                            Title = "Employee Page",
                            Route = nameof(EmployeePage),
                            ContentTemplate = new DataTemplate(typeof(EmployeePage)),
                        },
                        new ShellContent
                        {
                            Title = "Customers",
                            Route = nameof(CustomerPage),
                            ContentTemplate = new DataTemplate(typeof(CustomerPage)),
                        },
                        new ShellContent
                        {
                            Title = "Available Rooms",
                            Route = nameof(AvailableRoomPage),
                            ContentTemplate = new DataTemplate(typeof(AvailableRoomPage)),
                        },
                        new ShellContent
                        {
                            Title = "Unavailable Rooms",
                            Route = nameof(UnavailableRoomPage),
                            ContentTemplate = new DataTemplate(typeof(UnavailableRoomPage)),
                        }
                    }
                };

                if(App.employeeInfo.IsAdmin)
                {
                    flyoutItem.Items.Add(
                        new ShellContent
                        {
                            Route = "CreateEmployeePage",
                            Title = "Create Employee Page",
                            ContentTemplate = new DataTemplate(typeof(EmployeePage)),
                        });
                    flyoutItem.Items.Add(
                        new ShellContent
                        {
                            Route = nameof(EmployeeListPage),
                            Title = "Employee List",
                            ContentTemplate = new DataTemplate(typeof(EmployeeListPage)),
                        });
                }    

                if (!AppShell.Current.Items.Contains(flyoutItem))
                {                    
                    AppShell.Current.Items.Add(flyoutItem);      
                }

            }
        }
    }
}
