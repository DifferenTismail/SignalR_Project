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
        SignalRContext context = new SignalRContext();
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            return context.Products.Where(x => x.CategoryID == (context.Categorys
            .Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID)
            .FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            return context.Products.Where(x => x.CategoryID == (context.Categorys
            .Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID)
            .FirstOrDefault())).Count();
        }
    }
}
