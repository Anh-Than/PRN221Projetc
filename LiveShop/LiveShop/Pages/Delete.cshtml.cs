using LiveShop.Model;
using LiveShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiveShop.Pages
{
    public class DeleteModel : PageModel
    {
        ProductRepository productRepository;
        public DeleteModel(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            productRepository = new ProductRepository(connectionString);
        }
        public IActionResult OnGet(int id)
        {
            Car product = productRepository.GetProductByID(id);
            product.ReleasedYear -= 1;
            productRepository.UpdateProduct(product);
            return RedirectToPage("/Index");
        }
    }
}
