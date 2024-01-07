using System.Linq.Expressions;

namespace DeliveryAll.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
<<<<<<< HEAD
		IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,string? includeProperties = null);
		T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
=======
		IEnumerable<T> GetAll(string? includeProperties = null);
		T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b
		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entity); 
	}
}
