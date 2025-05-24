using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        public List<Discount> TGetActiveDiscount();
        public void TSetDicontPassive(int id);
        public void TSetDicontActive(int id);
    }
}
