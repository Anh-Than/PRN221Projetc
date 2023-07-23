using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreManagement.DataAcces;
using StoreManagement.Repository;
using StoreManagement.ViewModel;
using System.Data;

namespace StoreManagement.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class EditProductModel : PageModel
    {
        ProductRepository productRepository;
        [BindProperty(SupportsGet = true)]
        public List<Category> Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<Supplier> Suppliers { get; set; }

        [BindProperty]
        public EditProductView EditProductView { get; set; }
        public void OnGet(int id)
        {
            productRepository = new ProductRepository();
            Categories = productRepository.GetCategories();
            Suppliers = productRepository.GetSuppliers();
            EditProductView = productRepository.GetProductByID(id);
        }

        public IActionResult OnPost(EditProductView epv)
        {
            NorthwindContext context = new NorthwindContext();
            if (epv != null)
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == epv.ProductId);
                if (product != null)
                {
                    product.ProductName = EditProductView.ProductName;
                    product.SupplierId = EditProductView.SupplierId;
                    product.CategoryId = EditProductView.CategoryId;
                    product.UnitPrice = EditProductView.UnitPrice;
                    product.UnitsInStock = EditProductView.UnitsInStock;
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }            
            return RedirectToPage("/Shop/Storage");
        }
    }
}
