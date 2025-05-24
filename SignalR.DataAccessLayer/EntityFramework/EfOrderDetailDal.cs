using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EfOrderDetailDal(RestorantDbContext context) : base(context)
        {
        }

        public List<OrderDetail> GetOrderWithProduct()
        {
            var context = new RestorantDbContext();
            return context.OrderDetails.Include(x => x.Product).ToList();
        }

        public OrderDetail GetOrderWithProductByOrderid(int id)
        {
            var context = new RestorantDbContext();
            return context.OrderDetails.Include(x => x.Product).Where(x => x.OrderDetailId == id).FirstOrDefault();
        }
    }
}
