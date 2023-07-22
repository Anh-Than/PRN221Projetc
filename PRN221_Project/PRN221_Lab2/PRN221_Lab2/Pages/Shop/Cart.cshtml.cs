using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Lab2.DataAcces;
using PRN221_Lab2.Helper;

namespace PRN221_Lab2.Pages.Shop
{
    public class CartModel : PageModel
    {
        private readonly NorthwindContext dbContext;
        public List<Item> MyCart { get; set; }
        public decimal? Total = 0;
        public CartModel(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            MyCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Total = MyCart.Sum(item => item.Product.UnitPrice * item.Quantity);
        }

        public IActionResult OnGetDelete(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            var index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetBuy(int id)
        {
            var product = dbContext.Products.Find(id);
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        Product = product,
                        Quantity = 1
                    });
                }
                else
                {
                    var newQuantity = cart[index].Quantity + 1;
                    cart[index].Quantity = newQuantity;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetConfirm()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            foreach (var item in cart)
            {
                var product = dbContext.Products.FirstOrDefault(p => p.ProductId == item.Product.ProductId);
                product.UnitsInStock = (short?)(product.UnitsInStock - item.Quantity);
                dbContext.SaveChanges();
            }
            SessionHelper.RemoveSession(HttpContext.Session, "cart");
            return RedirectToPage("/Shop/Cart");
        }

        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
