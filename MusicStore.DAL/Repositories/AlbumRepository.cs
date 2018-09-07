using MusicStore.DAL.EF;
using MusicStore.DAL.Entities;
using MusicStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Repositories
{
    public class AlbumRepository:IRepository<Album>
    {
        private MusicStoreContext db;
        public AlbumRepository(MusicStoreContext context)
        {
            db = context;
        }

        public void Create(Album item)
        {
            db.Albums.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var Album = db.Albums.Find(id);
            if (Album != null)
                db.Albums.Remove(Album);
            db.SaveChanges();

        }

        public IEnumerable<Album> Find(Func<Album, bool> predicate)
        {
            return db.Albums.Include(s => s.Author).Include(b => b.Songs).Where(predicate).ToList();
        }

        public Album Get(int id)
        {
            return db.Albums.Include(s => s.Author).Include(b => b.Songs).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Album> GetAll()
        {
            return db.Albums.Include(s => s.Author).Include(b => b.Songs).ToList();
        }

        public void Update(Album item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
