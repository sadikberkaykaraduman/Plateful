using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        Product TGetProductsWithCategoriesByProductId(int id);
        List<Product> TGetFirst9Products();
        public int TProductCount();
        public int TProductCountByHamburgerCategory();
        public int TProductCountByWrapsCategory();
        public string TGetExpesive();
        public string TGetCheapest();
        public decimal TAverageProductPrice();
        public decimal TAverageHamburgerPrice();
        public decimal TProductPriceByBaconBurger();
        public decimal TTotalPriceByDessertsCategory();
        public decimal TTotalPriceBySaladCategory();
        public int TProductCountByBeveragesCategory();
        public decimal TProductPriceSummary(); 

    }
}
