using StoreManagement.DataAcces;

namespace StoreManagement.Repository
{
    public class ProductRepository
    {
        public List<Product> GetProductsList()
        {
            NorthwindContext _context = new NorthwindContext();
            List<Product> products = new List<Product>();
            products = _context.Products.Take(10).ToList();
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
                (_products,_categories) => new
                {
                    CategoryName = _categories.CategoryName,
                    CategoryId = _categories.CategoryId,
                    ProductId = _products.ProductId
                }).ToList();
            ProductForGraph productForGraph;

            foreach (var product in list)
            {
                if(!productsForGraph.Any(pg => pg.Category == product.CategoryName))
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
    }
}
