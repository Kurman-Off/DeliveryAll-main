using DeliveryAll.DataAccess.Data;
using DeliveryAll.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
=======
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b

namespace DeliveryAll.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
			_db.FoodItems.Include(u => u.category).Include(u=>u.CategoryId);
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}

<<<<<<< HEAD
		public T Get(Expression<Func<T, bool>> filter, string? includeProperties, bool tracked = false)
		{
			IQueryable<T> query;
            if (tracked)
			{
                query = dbSet;
            }
			else
			{
				query = dbSet.AsNoTracking();
            }
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

		public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if(filter!=null)
			{
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
=======
		public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if(!string.IsNullOrEmpty(includeProperties))
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b
			{
				foreach(var includeProp in includeProperties
					.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.ToList();
		}
	}
}
 