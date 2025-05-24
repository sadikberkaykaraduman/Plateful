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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(RestorantDbContext context) : base(context)
        {
        }

        public void ChangeMenuTableStatusToFalse(int id)
        {
            var context = new RestorantDbContext();
            var menuTable = context.MenuTables.Find(id);
            if (menuTable != null)
            {
                menuTable.MenuTableStatus = false;
                context.SaveChanges();
            }
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            var context = new RestorantDbContext();
            var menuTable = context.MenuTables.Find(id);
            if (menuTable != null)
            {
                menuTable.MenuTableStatus = true;
                context.SaveChanges();
            }
        }

        public int GetMenuTableCount()
        {
            var context = new RestorantDbContext();
            return context.MenuTables.Count();
        }
    }
}
