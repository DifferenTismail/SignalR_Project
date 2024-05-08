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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        SignalRContext context = new SignalRContext();
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            return context.Categorys.Where(x => x.CategoryStatus == true).Count();
        }

        public int CategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categorys.Count();
        }

        public int PassiveCategoryCount()
        {
            return context.Categorys.Where(x => x.CategoryStatus == false).Count();
        }
    }
}
