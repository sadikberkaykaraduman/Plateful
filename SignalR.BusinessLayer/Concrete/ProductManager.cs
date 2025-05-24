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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public Product TGetProductsWithCategoriesByProductId(int id)
        {
            return _productDal.GetProductsWithCategoriesByProductId(id);
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public int TProductCountByHamburgerCategory()
        {
            return _productDal.ProductCountByHamburgerCategory();
        }

        public int TProductCountByWrapsCategory()
        {
            return _productDal.ProductCountByWrapsCategory();
        }

        public decimal TAverageProductPrice()
        {
            return _productDal.AverageProductPrice();
        }

        public decimal TAverageHamburgerPrice()
        {
            return _productDal.AverageHamburgerPrice();
        }

        public string TGetExpesive()
        {
            return _productDal.GetExpesive();
        }

        public string TGetCheapest()
        {
            return _productDal.GetCheapest();
        }

        public decimal TProductPriceByBaconBurger()
        {
            return _productDal.ProductPriceByBaconBurger();
        }

        public decimal TTotalPriceByDessertsCategory()
        {
            return _productDal.TotalPriceByDessertsCategory();
        }

        public decimal TTotalPriceBySaladCategory()
        {
            return _productDal.TotalPriceBySaladCategory();
        }

        public int TProductCountByBeveragesCategory()
        {
            return _productDal.ProductCountByBeveragesCategory();
        }

        public decimal TProductPriceSummary()
        {
            return _productDal.ProductPriceSummary();
        }

        public List<Product> TGetFirst9Products()
        {
            return _productDal.GetFirst9Products();
        }
    }
}
