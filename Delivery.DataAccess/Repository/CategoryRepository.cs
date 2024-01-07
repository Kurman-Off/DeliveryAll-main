using DeliveryAll.DataAccess.Data;
using DeliveryAll.DataAccess.Repository;
using DeliveryAll.Models;
using DeliveryAll.Repository.IRepository;

<<<<<<< HEAD
namespace DeliveryAll.DataAccess.Repository
=======
namespace DeliveryAll.Repository
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Save()
		{
			_db.SaveChanges();
		}
		public void Update(Category obj)
		{
			_db.Categories.Update(obj);
		}
	}
}
