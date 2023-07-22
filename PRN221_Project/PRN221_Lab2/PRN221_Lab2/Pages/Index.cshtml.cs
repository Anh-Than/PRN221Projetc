using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Lab2.DataAcces;

namespace PRN221_Lab2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Lab2.DataAcces.NorthwindContext _context;

        public IndexModel(PRN221_Lab2.DataAcces.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
            }
        }
    }
}
