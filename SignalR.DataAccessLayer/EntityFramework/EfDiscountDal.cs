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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(RestorantDbContext context) : base(context)
        {
        }

        public List<Discount> GetActiveDiscount()
        {
            var context = new RestorantDbContext();
            return context.Discounts.Where(x => x.DiscountStatus == true).ToList();
        }

        public void SetDicontActive(int id)
        {
            var context = new RestorantDbContext();
            var value = context.Discounts.Find(id);
            value.DiscountStatus = true;
            context.SaveChanges();
        }

        public void SetDicontPassive(int id)
        {
            var context = new RestorantDbContext();
            var value = context.Discounts.Find(id);
            value.DiscountStatus = false;
            context.SaveChanges();
        }
    }
}
