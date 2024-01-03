using DeliveryAll.DataAccess.Data;
using DeliveryAll.DataAccess.Repository;
using DeliveryAll.Models;
using DeliveryAll.Repository.IRepository;

namespace DeliveryAll.DataAccess.Repository
{
	public class CartRepository : Repository<Cart>, ICartRepository
	{
		private ApplicationDbContext _db;
		public CartRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Save()
		{
			_db.SaveChanges();
		}
		public void Update(Cart obj)
		{
			_db.Carts.Update(obj);
		}
	}
}
