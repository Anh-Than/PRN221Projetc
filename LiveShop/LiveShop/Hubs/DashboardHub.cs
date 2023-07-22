using LiveShop.Model;
using LiveShop.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace LiveShop.Hubs
{
    public class DashboardHub : Hub
    {
        ProductRepository productRepository;
        public DashboardHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            productRepository = new ProductRepository(connectionString);
        }
        public async Task SendProducts()
        {
            var products = productRepository.GetProducts();
            await Clients.All.SendAsync("ReceivedProducts", products);
        }

        public void RemoveProduct(string id)
        {
            var product = productRepository.GetProductByID(int.Parse(id));
            productRepository.RemoveProduct(product);
        }
    }
}
