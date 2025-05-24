using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        List<Product> GetFirst9Products();
        Product GetProductsWithCategoriesByProductId(int id);
        public int ProductCount();
        public int ProductCountByHamburgerCategory();
        public int ProductCountByWrapsCategory();
        public string GetExpesive();
        public string GetCheapest();
        public decimal AverageProductPrice();
        public decimal AverageHamburgerPrice();
        public decimal ProductPriceByBaconBurger();
        public decimal TotalPriceByDessertsCategory();
        public decimal TotalPriceBySaladCategory();
        public int ProductCountByBeveragesCategory();
        public decimal ProductPriceSummary();
    }
}
