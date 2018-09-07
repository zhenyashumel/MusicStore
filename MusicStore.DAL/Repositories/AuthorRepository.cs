using MusicStore.DAL.EF;
using MusicStore.DAL.Entities;
using MusicStore.DAL.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Repositories
{
    public class AuthorRepository: IRepository<Author>
    {
        private MusicStoreContext db;
        public AuthorRepository(MusicStoreContext context)
        {
            db = context;
        }

        public void Create(Author item)
        {
            db.Authors.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
            db.SaveChanges();

        }

        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            return db.Authors.Include(a => a.Songs).Where(predicate).ToList();
        }

        public Author Get(int id)
        {
            return db.Authors.Include(a=>a.Songs).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors.Include(a => a.Songs).ToList();
        }

        public void Update(Author item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
