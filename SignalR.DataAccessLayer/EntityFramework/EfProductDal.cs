using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(RestorantDbContext context) : base(context)
        {
        }

        public decimal AverageHamburgerPrice()
        {
            var context = new RestorantDbContext();
            return context.Products.Where(x => x.ProductCategoryId == (context.Categories.Where(x => x.CategoryName== "Burgers").Select(x => x.CategoryId).FirstOrDefault())).Average(p => p.ProductPrice);
        }

        public decimal AverageProductPrice()
        {
            var context = new RestorantDbContext();
            return context.Products.Average(p => p.ProductPrice);
        }

        public List<Product> GetFirst9Products()
        {
            var context = new RestorantDbContext();
            return context.Products.Take(9).ToList();
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new RestorantDbContext();
            return context.Products.Include(p => p.Category).ToList();
        }

        public Product GetProductsWithCategoriesByProductId(int id)
        {
            var context = new RestorantDbContext();
            return context.Products.Include(p => p.Category).Where(p => p.ProductId == id).FirstOrDefault();
        }

        public int ProductCount()
        {
            var context = new RestorantDbContext();
            return context.Products.Count();
        }

        public int ProductCountByBeveragesCategory()
        {
            var context = new RestorantDbContext();
            return context.Products.Where(x => x.ProductCategoryId == (context.Categories.Where(x => x.CategoryName == "Beverages").Select(x => x.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByHamburgerCategory()
        {
            var context = new RestorantDbContext();
            return context.Products.Where(x => x.ProductCategoryId == (context.Categories.Where(x => x.CategoryName == "Burgers").Select(x => x.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByWrapsCategory()
        {
            var context = new RestorantDbContext();
            return context.Products.Where(x => x.ProductCategoryId == (context.Categories.Where(x => x.CategoryName == "Wraps").Select(x => x.CategoryId).FirstOrDefault())).Count();
        }

        public decimal ProductPriceByBaconBurger()
        {
            var context = new RestorantDbContext();
            return context.Products.Where(x => x.ProductName == "Bacon Burger").Select(x => x.ProductPrice).FirstOrDefault();
        }

        public decimal ProductPriceSummary()
        {
            var context = new RestorantDbContext();
            return context.Products.Sum(p => p.ProductPrice);
        }

        public decimal TotalPriceByDessertsCategory()
        {
            var context = new RestorantDbContext();
            return context.Products.Where(x => x.ProductCategoryId == (context.Categories.Where(x => x.CategoryName == "Desserts").Select(x => x.CategoryId).FirstOrDefault())).Sum(p => p.ProductPrice);
        }

        public decimal TotalPriceBySaladCategory()
        {
            var context = new RestorantDbContext();
            return context.Products.Where(x => x.ProductCategoryId == (context.Categories.Where(x => x.CategoryName == "Salads").Select(x => x.CategoryId).FirstOrDefault())).Sum(p => p.ProductPrice);
        }

        string IProductDal.GetCheapest()
        {
            var context = new RestorantDbContext();
            return context.Products.OrderBy(p => p.ProductPrice).Select(x => x.ProductName).FirstOrDefault();
        }

        string IProductDal.GetExpesive()
        {
            var context = new RestorantDbContext();
            return context.Products.OrderByDescending(p => p.ProductPrice).Select(x => x.ProductName).FirstOrDefault();
        }
    }
}
