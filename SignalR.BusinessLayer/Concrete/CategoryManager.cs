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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int TCategoryCount()
        {
            return _categoryDal.CategoryCount();
        }

        public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category TGetById(int id)
        {
            var value = _categoryDal.GetById(id);
            return value;
        }

        public List<Category> TGetListAll()
        {
            var values = _categoryDal.GetListAll();
            return values;
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public int TActiveCategoryCount()
        {
            return _categoryDal.ActiveCategoryCount();
        }

        public int TPasssiveCategoryCount()
        {
            return _categoryDal.PasssiveCategoryCount();
        }
    }
}
