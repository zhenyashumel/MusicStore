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
    public class SongRepository : IRepository<Song>
    {
        private MusicStoreContext db;
        public SongRepository(MusicStoreContext context)
        {
            db = context;
        }

        public void Create(Song item)
        {
            db.Songs.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var song = db.Songs.Find(id);
            if (song != null)
                db.Songs.Remove(song);
            db.SaveChanges();

        }

        public IEnumerable<Song> Find(Func<Song, bool> predicate)
        {
            return db.Songs.Include(s => s.Album).Include(b => b.Author).Where(predicate).ToList();
        }

        public Song Get(int id)
        {
            return db.Songs.Include(s=>s.Album).Include(b=>b.Author).FirstOrDefault(p=>p.Id == id);
        }

        public IEnumerable<Song> GetAll()
        {
            return db.Songs.Include(s => s.Album).Include(b => b.Author).ToList();
        }

        public void Update(Song item)
        {
            db.Entry(item).State =EntityState.Modified;
        }
    }
}
