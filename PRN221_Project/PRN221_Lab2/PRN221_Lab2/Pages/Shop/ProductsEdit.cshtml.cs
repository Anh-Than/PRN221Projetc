using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Lab2.DataAcces;

namespace PRN221_Lab2.Pages.Shop
{
    public class ProductsEditModel : PageModel
    {
        private readonly NorthwindContext _context;
        public ProductsEditModel(NorthwindContext context)
        {
            this._context = context;
        }
        public Product Product { get; set; }
        public IActionResult OnGet(int id)
        {
            Product = GetProductById(id);
            if(Product == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(Product product)
        {
            Product = GetProductById(product.ProductId);
            if(Product != null)
            {
                Product.ProductName = product.ProductName;
                Product.UnitsInStock = product.UnitsInStock;
                Product.UnitPrice = product.UnitPrice;
                _context.SaveChanges();
            }
            return RedirectToPage("/Shop/ProductsList");
        }

        private Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
