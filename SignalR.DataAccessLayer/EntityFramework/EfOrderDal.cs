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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(RestorantDbContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            var context = new RestorantDbContext();
            return context.Orders.Count(x => x.OrderStatus == true);
        }

        public decimal LastOrderAmount()
        {
            var context = new RestorantDbContext();
            var lastOrder = context.Orders.OrderByDescending(x => x.OrderId).Select(x => x.OrderTotalPrice).FirstOrDefault();
            return lastOrder;
        }

        public int OrderCount()
        {
            var context = new RestorantDbContext();
            return context.Orders.Count();
        }

        public int PassiveOrderCount()
        {
            var context = new RestorantDbContext();
            return context.Orders.Count(x => x.OrderStatus == false);
        }

        public decimal TodayIncome()
        {
            var context = new RestorantDbContext();
            var today = DateTime.Now.Day;
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var todayIncome = context.Orders.Where(x => x.OrderDate.Day == today && x.OrderDate.Month == month && x.OrderDate.Year == year).Sum(x => x.OrderTotalPrice);
            return todayIncome;
        }
    }
}
