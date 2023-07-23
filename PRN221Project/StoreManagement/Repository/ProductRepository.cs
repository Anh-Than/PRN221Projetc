using StoreManagement.DataAcces;
using StoreManagement.ViewModel;

namespace StoreManagement.Repository
{
    public class ProductRepository
    {
        public List<Product> GetProductsList()
        {
            NorthwindContext _context = new NorthwindContext();
            List<Product> products = new List<Product>();
            products = _context.Products.ToList();
            return products;
        }

        public List<ProductView> GetProductViewsList()
        {
            NorthwindContext _context = new NorthwindContext();
            List<ProductView> products = new List<ProductView>();
            var list = _context.Products
                .Join(_context.Categories,
                p => p.CategoryId,
                c => c.CategoryId,
                (p, c) => new { p, c })
                .Join(_context.Suppliers,
                pc => pc.p.SupplierId,
                s => s.SupplierId,
                (pc, s) => new
                {
                    Id = pc.p.ProductId,
                    Name = pc.p.ProductName,
                    Supplier = s.CompanyName,
                    SupplierId = s.SupplierId,
                    Category = pc.c.CategoryName,
                    CategoryId = pc.c.CategoryId,
                    Price = pc.p.UnitPrice,
                    InStock = pc.p.UnitsInStock
                }).ToList();
            ProductView product;
            foreach (var p in list)
            {
                product = new ProductView
                {
                    Id = p.Id,
                    Name = p.Name,
                    Supplier = p.Supplier,
                    SupplierId = p.SupplierId,
                    Category = p.Category,
                    CategoryId = p.CategoryId,
                    Price = p.Price,
                    UnitInStock = p.InStock
                };
                products.Add(product);
            }
            return products;
        }

        public List<ProductForGraph> GetProductsForGraph()
        {
            NorthwindContext _context = new NorthwindContext();
            List<ProductForGraph> productsForGraph = new List<ProductForGraph>();
            List<Product> products = new List<Product>();
            products = GetProductsList();

            var list = _context.Products.Join(_context.Categories,
                p => p.CategoryId,
                c => c.CategoryId,
                (_products, _categories) => new
                {
                    CategoryName = _categories.CategoryName,
                    CategoryId = _categories.CategoryId,
                    ProductId = _products.ProductId
                }).ToList();
            ProductForGraph productForGraph;

            foreach (var product in list)
            {
                if (!productsForGraph.Any(pg => pg.Category == product.CategoryName))
                {
                    productForGraph = new ProductForGraph
                    {
                        Category = product.CategoryName,
                        Products = 1
                    };
                    productsForGraph.Add(productForGraph);
                }
                else
                {
                    productsForGraph.FirstOrDefault(pg => pg.Category == product.CategoryName).Products++;
                }
            }

            return productsForGraph;
        }

        public List<Category> GetCategories()
        {
            NorthwindContext _context = new NorthwindContext();
            List<Category> categories = new List<Category>();
            categories = _context.Categories.ToList();
            return categories;
        }

        public List<Supplier> GetSuppliers()
        {
            NorthwindContext _context = new NorthwindContext();
            List<Supplier> suppliers = new List<Supplier>();
            suppliers = _context.Suppliers.ToList();
            return suppliers;
        }

        public EditProductView GetProductByID(int id)
        {
            NorthwindContext _context = new NorthwindContext();
            Product p = _context.Products.FirstOrDefault(p => p.ProductId == id);
            EditProductView ew = new EditProductView
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock
            };
            return ew;
        }
    }
}
