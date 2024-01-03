using DeliveryAll.Models.ViewModels;
using DeliveryAll.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeliveryApp.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize]
    public class CartController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        public CartVM CartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CartVM = new()
            {
                CartList = _unitOfWork.Cart.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "FoodItem")
            };
            foreach (var cart in CartVM.CartList)
            {
                cart.Price = cart.FoodItem.Price;
                CartVM.OrderTotal += (cart.Price * cart.Count);
            }
            return View(CartVM);
        }
        public IActionResult Summary()
        {
            return View();
        }
        public IActionResult Plus(int cartId) {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId);
            cartFromDb.Count += 1;
            _unitOfWork.Cart.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId);
            if (cartFromDb.Count <= 1)
            {
                _unitOfWork.Cart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.Cart.Update(cartFromDb);
            }
           
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId);
             _unitOfWork.Cart.Remove(cartFromDb);
 

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }
    }
}
