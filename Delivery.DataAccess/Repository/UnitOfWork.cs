using DeliveryAll.DataAccess.Data;
using DeliveryAll.DataAccess.Repository.IRepository;
using DeliveryAll.Repository.IRepository;

namespace DeliveryAll.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;
		public ICategoryRepository Category { get; private set; }
        public IFoodItemRepository FoodItem { get; private set; }

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
			FoodItem = new FoodItemrepository(_db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
