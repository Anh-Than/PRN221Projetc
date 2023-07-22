using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using PRN221_Lab2.DataAcces;

namespace PRN221_Lab2.Pages.Shop
{
    public class ProductListModel : PageModel
    {
        private readonly NorthwindContext dbContext;
        public List<Product> Products { get; set; }

        public List<Product> data { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public string AmountSort { get; set; }
        public ProductListModel(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(string searchString = "", string sortOrder = "", int pg = 1)
        {
            Products = dbContext.Products.ToList();
            CurrentFilter = searchString;
            
            if (searchString != null)
            {
                pg = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }
            CurrentSort = sortOrder;

            if (sortOrder.Equals(""))
            {
                sortOrder = "desc";
                CurrentSort = sortOrder;
            }
            else if (sortOrder.Equals("desc"))
            {
                sortOrder = "asc";
                CurrentSort = sortOrder;
            }
            else if (sortOrder.Equals("asc"))
            {
                sortOrder = "";
                CurrentSort = sortOrder;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                Products = Products.Where(p => p.ProductName.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "desc":
                    Products = Products.OrderByDescending(p => p.UnitsInStock).ToList();
                    break;
                case "asc":
                    Products = Products.OrderBy(p => p.UnitsInStock).ToList();
                    break;
                default:
                    break;
            }

            const int pageSize = 10;
            if (pg < 1) pg = 1;

            int recsCount = Products.Count;

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            data = Products.Skip(recSkip).Take(pager.PageSize).ToList();

            ViewData["Pager"] = pager;
        }

    }
}
