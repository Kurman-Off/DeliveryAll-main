using DeliveryAll.DataAccess.Data;
using DeliveryAll.DataAccess.Repository.IRepository;
using DeliveryAll.Repository.IRepository;

<<<<<<< HEAD
namespace DeliveryAll.DataAccess.Repository
=======
namespace DeliveryAll.Repository
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;
		public ICategoryRepository Category { get; private set; }
        public IFoodItemRepository FoodItem { get; private set; }
<<<<<<< HEAD
		public ICartRepository Cart { get; private set; }
		public IApplicationUserRepository ApplicationUser { get; private set; }

		 
        public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			ApplicationUser = new ApplicationUserRepository(_db);
            Cart = new CartRepository(_db);
=======

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b
			Category = new CategoryRepository(_db);
			FoodItem = new FoodItemrepository(_db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
