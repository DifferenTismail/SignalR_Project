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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }
        SignalRContext context = new SignalRContext();
        public int TotalOrderCount()
        {
            return context.Orders.Count();   
        }

        public int ActiveOrderCount()
        {
            return context.Orders.Where(x => x.Description == "Musteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y =>y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            //return context.Orders.Where(x => x.Date == DateTime.Parse(DateTime.Now.ToShortDateString()))
            //    .Sum(y => y.TotalPrice);
            return 0;
        }
    }
}
