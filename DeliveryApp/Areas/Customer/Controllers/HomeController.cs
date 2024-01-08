﻿using DeliveryAll.Models;
using DeliveryAll.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Diagnostics;
using System.Security.Claims;

namespace DeliveryAll.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<FoodItem> foodItemList = _unitOfWork.FoodItem.GetAll(includeProperties: "category");
            return View(foodItemList);
        }
        public IActionResult Details(int foodItemId)
        {
            Cart cart = new()
            {
                FoodItem = _unitOfWork.FoodItem.Get(u => u.Id == foodItemId, includeProperties: "category"),
                Count = 1,
                FoodItemId = foodItemId
            };
            return View(cart);   
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(Cart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            cart.ApplicationUserId = userId;

            Cart cartFromDb = _unitOfWork.Cart.Get(u => u.ApplicationUserId == userId && 
             u.FoodItemId == cart.FoodItemId);

            if(cartFromDb != null)
            {
                cartFromDb.Count += cart.Count;
                _unitOfWork.Cart.Update(cartFromDb);
            }
            else
            {
                _unitOfWork.Cart.Add(cart);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}