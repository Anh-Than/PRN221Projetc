using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.DataAcces;
using System.Data;

namespace StoreManagement.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class DeleteProductModel : PageModel
    {
        NorthwindContext _context;
        public IActionResult OnGet(int id)
        {

            _context = new NorthwindContext();
            Product p = _context.Products.FirstOrDefault(p => p.ProductId == id);
            _context.Products.Remove(p);
            _context.SaveChanges();
            return RedirectToPage("/Shop/Storage");
        }
    }
}
