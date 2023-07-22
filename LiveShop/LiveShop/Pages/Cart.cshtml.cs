using LiveShop.Helper;
using LiveShop.Model;
using LiveShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiveShop.Pages
{
    public class CartModel : PageModel
    {
        ProductRepository productRepository;
        public List<Item> MyCart { get; set; }
        public decimal? Total = 0;
        public CartModel(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            productRepository = new ProductRepository(connectionString);
        }

        public void OnGet()
        {
            MyCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (MyCart != null)
            {
                Total = MyCart.Sum(item => item.Car.Price * item.Quantity);
            }        
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
            var product = productRepository.GetProductByID(id);
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    Car = product,
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
                        Car = product,
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
        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Car.ID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult OnGetConfirm()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            foreach (var item in cart)
            {
                var product = productRepository.GetProductByID(item.Car.ID);
                product.ReleasedYear = product.ReleasedYear - item.Quantity;
                productRepository.UpdateProduct(product);
            }
            SessionHelper.RemoveSession(HttpContext.Session, "cart");
            return RedirectToPage("/Cart");
        }
    }
}
