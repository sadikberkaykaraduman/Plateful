using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public int TActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public decimal TLastOrderAmount()
        {
            return _orderDal.LastOrderAmount();
        }

        public int TPassiveOrderCount()
        {
            return _orderDal.PassiveOrderCount();
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }

        public decimal TTodayIncome()
        {
            return _orderDal.TodayIncome();
        }

        public int TOrderCount()
        {
            return _orderDal.OrderCount();
        }
    }
}
