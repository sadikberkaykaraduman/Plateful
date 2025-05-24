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
    public class EfCashRegisterDal : GenericRepository<CashRegister>, ICashRegisterDal
    {
        public EfCashRegisterDal(RestorantDbContext context) : base(context)
        {
        }

        public decimal GetTotalCashRegisterAmount()
        {
            var context = new RestorantDbContext();
            return context.CashRegisters.Select(x => x.CashRegisterAmount).FirstOrDefault();
        }
    }
}
