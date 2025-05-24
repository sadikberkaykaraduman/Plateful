using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        public List<Discount> GetActiveDiscount();
        public void SetDicontPassive(int id);
        public void SetDicontActive(int id);
    }
}
