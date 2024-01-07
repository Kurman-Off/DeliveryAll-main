using DeliveryAll.DataAccess.Repository.IRepository;

namespace DeliveryAll.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }
		IFoodItemRepository FoodItem { get; }
<<<<<<< HEAD
		ICartRepository Cart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
=======
		void Save();
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b
	}
}
