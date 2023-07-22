using Microsoft.AspNetCore.SignalR;
using StoreManagement.DataAcces;
using StoreManagement.Repository;

namespace StoreManagement.Hubs
{
    public class DashboardHub : Hub
    {
        ProductRepository productRepository;
        EmployeeRepository employeeRepository;
        public DashboardHub()
        {
            productRepository = new ProductRepository();
            employeeRepository = new EmployeeRepository();
        }
        public async Task SendProducts()
        {
            var products = productRepository.GetProductsList();
            await Clients.All.SendAsync("ReceivedProducts", products);

            var productsForGraph = productRepository.GetProductsForGraph();
            await Clients.All.SendAsync("ReceivedProductsForGraph", productsForGraph);
        }

        public async Task SendEmployees()
        {
            var employees = employeeRepository.GetEmployeesList();
            Console.WriteLine(employees.Count);
            await Clients.All.SendAsync("ReceivedEmployees", employees);

            var employeesForGraph = employeeRepository.GetEmployeesForGraph();
            await Clients.All.SendAsync("ReceivedEmployeesForGraph", employeesForGraph);
        }
    }
}
