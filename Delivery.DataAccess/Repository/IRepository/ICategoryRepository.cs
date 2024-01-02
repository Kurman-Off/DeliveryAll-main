using DeliveryAll.Models;

namespace DeliveryAll.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category category);
		void Save();
	}
}
