using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        public int TOrderCount();
        public int TActiveOrderCount();
        public int TPassiveOrderCount();
        public decimal TLastOrderAmount(); 
        public decimal TTodayIncome();
    }
}
