using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PRN221_Lab2.DataAcces;
using PRN221_Lab2.Helper;

namespace PRN221_Lab2.Pages.Shop
{
    public class ProductsListModel : PageModel
    {
        private readonly NorthwindContext _context;
        public ProductsListModel(NorthwindContext context)
        {
            this._context = context;
        }
        public List<Product> products { get; set; }
        public List<Product> data { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; }
        public void OnGet(string sortOrder, string searchTerm, int pg = 1 )
        {
            products = _context.Products.ToList();
            searchTerm = SearchTerm;
            products = Search(searchTerm, products).ToList();
            if(HttpContext.Session.GetString("username") == null)
            {
                ViewData["username"] = string.Empty;
            }
            else
            {
                ViewData["username"] = HttpContext.Session.GetString("username");
            }
            

            if (sortOrder == null)
            {
                sortOrder = "";
            }
            CurrentSort = sortOrder;

            if (CurrentSort.Equals("desc"))
            {
                products = products.OrderByDescending(p => p.UnitsInStock).ToList(); 
            }else if (CurrentSort.Equals("asc"))
            {
                products = products.OrderBy(p => p.UnitsInStock).ToList();
            }

            if(sortOrder.Equals(""))
            {
                CurrentSort = "desc";
            }else if(sortOrder.Equals("desc"))
            {
                CurrentSort = "asc";
            }else if(sortOrder.Equals("asc"))
            {
                CurrentSort = "";
            }

            const int pageSize = 10;
            if (pg < 1) pg = 1;

            int recsCount = products.Count;

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            data = products.Skip(recSkip).Take(pager.PageSize).ToList();

            ViewData["Pager"] = pager;
        }

        public IEnumerable<Product> Search(string searchTerm, List<Product> products)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return products;
            }
            return products.Where(p => p.ProductName.Contains(searchTerm));
        }
        
    }
}
