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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(RestorantDbContext context) : base(context)
        {
        }

        public List<Basket> GetListWithProductByMenuTableId(int id)
        {
            var context = new RestorantDbContext();
            return context.Baskets.Include(x => x.Product).Where(x => x.BasketMenuTableId == id).ToList();
        }
    }
}
