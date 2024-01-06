using DeliveryAll.DataAccess.Repository.IRepository;

namespace DeliveryAll.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }
		IFoodItemRepository FoodItem { get; }
		void Save();
	}
}
