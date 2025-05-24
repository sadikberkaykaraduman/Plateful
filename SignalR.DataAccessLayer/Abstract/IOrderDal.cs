using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        public int OrderCount();
        public int ActiveOrderCount();
        public int PassiveOrderCount();
        public decimal LastOrderAmount();
        public decimal TodayIncome();
    }
}
