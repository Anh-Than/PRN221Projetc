using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.DataAcces;
using StoreManagement.Repository;
using StoreManagement.ViewModel;
using System.Data;

namespace StoreManagement.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class AddProductModel : PageModel
    {
        ProductRepository productRepository;
        [BindProperty(SupportsGet = true)]
        public List<Category> Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<Supplier> Suppliers { get; set; }
        
        [BindProperty]
        public AddProductView AddProductView { get; set; }
        public void OnGet()
        {
            productRepository = new ProductRepository();
            Categories = productRepository.GetCategories();
            Suppliers = productRepository.GetSuppliers();
        }

        public IActionResult OnPost()
        {
            NorthwindContext context = new NorthwindContext();
            var product = new Product
            {
                ProductName = AddProductView.ProductName,
                SupplierId = AddProductView.SupplierId,
                CategoryId = AddProductView.CategoryId,
                UnitPrice = AddProductView.UnitPrice,
                UnitsInStock = AddProductView.UnitsInStock
            };
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToPage("/Shop/Storage");
        }
    }
}
