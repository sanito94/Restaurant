using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Restaurant.Core.Contracts;
using Restaurant.Core.Models.Cart;
using Restaurant.Extensions;
using Restaurant.Infrastructure.Data;
using Restaurant.Infrastructure.Data.Models;
using Stripe.Checkout;

namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly RestaurantDbContext context;

        public CartController(
            ICartService _cartService,
            RestaurantDbContext _context)
        {
            cartService = _cartService;
            context = _context;
        }

        public async Task<IActionResult> All()
        {
            var cart = await context.Carts
                .AsNoTracking()
                .Where(c => c.UserId == User.Id())
                .Select(c => new CartViewModel()
                {
                    Id = c.Id,
                    ItemName = c.ItemName,
                    ItemId = c.ItemId,
                    Amount = c.Amount,
                    ImageUrl = c.ImageUrl,
                    UserId = User.Id(),
                    Price = c.Price,
                })
                .ToListAsync();

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            if (await cartService.ItemExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = User.Id();

            var item = await cartService.ItemDetailsByIdAsync(id);

            if (item == null)
            {
                return BadRequest();
            }

            var cart = await context.Carts
                .Where(c => c.UserId == userId && c.ItemId == id)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                var cartCreate = new Cart()
                {
                    ItemId = id,
                    ItemName = item.Name,
                    UserId = userId,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price,
                    Amount = item.Amount,
                    Total = item.Price * item.Amount
                };

                await context.Carts.AddAsync(cartCreate);
                await context.SaveChangesAsync();
                return RedirectToAction("All", "Cart");
            }

            cart.Amount += 1;
            cart.Total += item.Price;
            await context.SaveChangesAsync();
            return RedirectToAction("All", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> PlusAmount(int id)
        {
            var shoppingCartItem = await context.Carts
                .Where(c => c.UserId == User.Id() && c.ItemId == id)
                .FirstOrDefaultAsync();

            if (shoppingCartItem != null)
            {
                shoppingCartItem.Amount++;
                shoppingCartItem.Total = shoppingCartItem.Amount * shoppingCartItem.Price;

                await context.SaveChangesAsync();

                var model = await cartService.CartTotalAsync(User.Id());

                double subTotal = 0;

                foreach (var item in model)
                {
                    subTotal += item.Total;
                }

                var itemWithSubTotalValue = await context.Carts
                .Where(c => c.UserId == User.Id() && c.SubTotal > 0)
                .FirstOrDefaultAsync();

                if (itemWithSubTotalValue != null)
                {
                    itemWithSubTotalValue.SubTotal = subTotal;
                }
                else
                {
                    shoppingCartItem.SubTotal = subTotal;
                }

            }

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> MinusAmount(int id)
        {
            var shoppingCartItem = await context.Carts
                .Where(c => c.UserId == User.Id() && c.ItemId == id)
                .FirstOrDefaultAsync();

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount == 1)
                {
                    await cartService.DeleteAsync(shoppingCartItem.Id);
                }
                else
                {
                    shoppingCartItem.Amount--;
                    shoppingCartItem.Total = shoppingCartItem.Amount * shoppingCartItem.Price;

                    await context.SaveChangesAsync();

                    var model = await cartService.CartTotalAsync(User.Id());

                    double subTotal = 0;

                    foreach (var item in model)
                    {
                        subTotal += item.Total;
                    }

                    var itemWithSubTotalValue = await context.Carts
                    .Where(c => c.UserId == User.Id() && c.SubTotal > 0)
                    .FirstOrDefaultAsync();

                    if (itemWithSubTotalValue != null)
                    {
                        itemWithSubTotalValue.SubTotal = subTotal;
                    }
                    else
                    {
                        shoppingCartItem.SubTotal = subTotal;
                    }
                }
            }

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var shoppingCartItem = await context.Carts
               .Where(c => c.UserId == User.Id() && c.ItemId == id)
               .FirstOrDefaultAsync();

            if (shoppingCartItem != null)
            {
                await cartService.DeleteAsync(shoppingCartItem.Id);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("All", "Cart");
        }

        public async Task<IActionResult> CreateCheckoutSession()
        {
            var domain = "https://localhost:7081/";

            var items = await context.Carts.Where(c => c.UserId == User.Id()).ToListAsync();

            if (items.Count() == 0)
            {
                return RedirectToAction("Menu", "Menu");
            }

            var options = new SessionCreateOptions
            {

                Mode = "payment",
                SuccessUrl = domain + $"Cart/OrderConfirmation",
                CancelUrl = domain + $"Cart/All",
                LineItems = new List<SessionLineItemOptions>(),
            };

            foreach (var item in items)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100),
                        Currency = "eur",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.ItemName.ToString(),
                        }
                    },
                    Quantity = item.Amount
                };
                options.LineItems.Add(sessionListItem);
            }

            var service = new SessionService();
            var session = service.Create(options);

            TempData["Session"] = session.Id;

            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult OrderConfirmation()
        {
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());

            if (session.PaymentStatus == "paid")
            {
                return RedirectToAction(nameof(Success));
            }
            return RedirectToAction(nameof(All));
        }
    }
}
