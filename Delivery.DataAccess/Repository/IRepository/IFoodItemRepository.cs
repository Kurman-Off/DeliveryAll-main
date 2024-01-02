using DeliveryAll.Models;
using DeliveryAll.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAll.DataAccess.Repository.IRepository
{
    public interface IFoodItemRepository : IRepository<FoodItem>
    {
        void Update(FoodItem obj);
    }
}
