using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Lab2.DataAcces;

namespace PRN221_Lab2.Pages.Shop
{
    public class ProductDetailsModel : PageModel
    {
        private readonly NorthwindContext _context;
        public ProductDetailsModel(NorthwindContext context)
        {
            this._context = context;
        }
        public Product Product { get; private set; }
        public void OnGet(int id = 1)
        {
            Product = GetProductById(id);
        }
        private Product GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p =>p.ProductId == id);
            if(product == null)
            {
                return new Product();
            }
            else
            {
                return product;
            }
        }
    }
}
