using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.DataAcces;
using StoreManagement.Repository;
using StoreManagement.ViewModel;
using System.Data;

namespace StoreManagement.Pages.Shop
{
    [Authorize(Roles = "Admin")]
    public class StorageModel : PageModel
    {
        private ProductRepository productRepository;
        public List<ProductView> Products { get; set; }
        public List<ProductView> data { get; set; }
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int categoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int supplierId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal minPrice { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal maxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal searchMinPrice { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal searchMaxPrice { get; set; }
        public void OnGet(string isSort, string sortOrder, string searchTerm, int category, int supplier, decimal min, decimal max, int pg = 1)
        {
            productRepository = new ProductRepository();
            Products = productRepository.GetProductViewsList();
            Categories = productRepository.GetCategories();
            Suppliers = productRepository.GetSuppliers();

            minPrice = (decimal)Products.Select(p => p.Price).DefaultIfEmpty(0).Min();
            maxPrice = (decimal)Products.Select(p => p.Price).DefaultIfEmpty(0).Max();

            min = searchMinPrice;
            max = searchMaxPrice;

            searchTerm = SearchTerm;
            if (sortOrder == null)
            {
                sortOrder = "";
            }
            CurrentSort = sortOrder;
            Products = Search(category, supplier, searchTerm, min, max, Products).ToList();

            if (!string.IsNullOrEmpty(isSort))
            {
                if (sortOrder.Equals(""))
                {
                    CurrentSort = "desc";
                }
                else if (sortOrder.Equals("desc"))
                {
                    CurrentSort = "asc";
                }
                else if (sortOrder.Equals("asc"))
                {
                    CurrentSort = "";
                }
            }

            if (CurrentSort.Equals("desc"))
            {
                Products = Products.OrderByDescending(p => p.UnitInStock).ToList();
            }
            else if (CurrentSort.Equals("asc"))
            {
                Products = Products.OrderBy(p => p.UnitInStock).ToList();
            }          
           
            const int pageSize = 10;
            if (pg < 1) pg = 1;

            int recsCount = Products.Count;

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            data = Products.Skip(recSkip).Take(pager.PageSize).ToList();

            ViewData["Pager"] = pager;
        }

        public IActionResult OnGetAdd()
        {
            return RedirectToPage("/Products/AddEmployee");
        }

        public IEnumerable<ProductView> Search(int category, 
            int supplier, 
            string searchTerm, 
            decimal min,
            decimal max,
            List<ProductView> products)
        {
            //search for price
            if(min >= 0 && max != 0)
            {
                products = products.Where(p => p.Price >= min).Where(p => p.Price <= max).ToList();
                searchMinPrice = min;
                searchMaxPrice = max;
            }else if(min == 0 && max == 0)
            {
                searchMinPrice = minPrice;
                searchMaxPrice = maxPrice;
            }
            

            //search for other
            if (string.IsNullOrEmpty(searchTerm) && category != 0 && supplier == 0)
            {
                categoryId = category;
                return products
                    .Where(p => p.CategoryId == category);
            }

            if (string.IsNullOrEmpty(searchTerm) && category == 0 && supplier != 0)
            {
                supplierId = supplier;
                return products
                    .Where(p => p.SupplierId == supplier);
            }

            if (string.IsNullOrEmpty(searchTerm) && category != 0 && supplier != 0)
            {
                supplierId = supplier;
                categoryId = category;
                return products
                    .Where(p => p.SupplierId == supplier)
                    .Where(p => p.CategoryId == category);
            }

            if (!string.IsNullOrEmpty(searchTerm) && category == 0 && supplier == 0)
            {
                return products
                    .Where(p => p.Name.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(searchTerm) && category != 0 && supplier == 0)
            {
                categoryId = category;
                return products
                    .Where(p => p.Name.Contains(searchTerm))
                    .Where(p => p.CategoryId == category);
            }

            if (!string.IsNullOrEmpty(searchTerm) && category == 0 && supplier != 0)
            {
                supplierId = supplier;
                return products
                    .Where(p => p.Name.Contains(searchTerm))
                    .Where(p => p.SupplierId == supplier);
            }

            if (!string.IsNullOrEmpty(searchTerm) && category != 0 && supplier != 0)
            {
                supplierId = supplier;
                categoryId = category;
                return products
                    .Where(p => p.Name.Contains(searchTerm))
                    .Where(p => p.SupplierId == supplier)
                    .Where(p => p.CategoryId == category);
            }
            return products;
        }
    }
}
