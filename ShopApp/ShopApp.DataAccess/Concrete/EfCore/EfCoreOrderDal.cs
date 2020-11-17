using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderDal : EfCoreGenericRepository<Order, ShopContext>, IOrderDal
    {
        public List<Order> GetOrders(string userId)
        {
            //order, orderiçindeki orderitem ve orderitem içindeki productlar

            using (var context=new ShopContext())
            {
                var orders = context.Orders
                              .Include(i => i.OrderItems)
                              .ThenInclude(i => i.Product)
                              .AsQueryable();//sonradan sorgu yazılabilir
                if (!string.IsNullOrEmpty(userId))
                {
                    orders= orders.Where(i=>i.UserId==userId);
                }

                return orders.ToList();
            }
        }
    }
}
