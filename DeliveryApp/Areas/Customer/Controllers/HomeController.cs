using DeliveryAll.Models;
using DeliveryAll.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
			FoodItem foodItem = _unitOfWork.FoodItem.Get(u=>u.Id==foodItemId, includeProperties: "category");
			return View(foodItem);
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