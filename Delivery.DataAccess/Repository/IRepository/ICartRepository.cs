using DeliveryAll.Models;

namespace DeliveryAll.Repository.IRepository
{
	public interface ICartRepository : IRepository<Cart>
	{
		void Update(Cart obj);
	}
}
