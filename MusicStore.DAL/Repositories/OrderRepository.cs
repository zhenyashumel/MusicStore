using MusicStore.DAL.EF;
using MusicStore.DAL.Entities;
using MusicStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.DAL.Repositories
{
    public class OrderRepository:IRepository<Order>
    {
        private MusicStoreContext db;
        public OrderRepository(MusicStoreContext context)
        {
            db = context;
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var Order = db.Orders.Find(id);
            if (Order != null)
                db.Orders.Remove(Order);
            db.SaveChanges();

        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public void Update(Order item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
