using MusicStore.DAL.EF;
using MusicStore.DAL.Entities;
using MusicStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private MusicStoreContext _db;
        private IRepository<Song> _songRepo;
        private IRepository<Author> _authorRepo;
        private IRepository<Album> _albumRepo;
        private IRepository<Order> _orderRepo;
        private bool isDisposed = false;
        public EFUnitOfWork(string connectionString)
        {
            _db = new MusicStoreContext(connectionString);
        }

        public IRepository<Song> Songs
        {
            get
            {
                if (_songRepo == null)
                    _songRepo = new SongRepository(_db);
                return _songRepo;
            }
        }

        public IRepository<Author> Authors
        {
            get
            {
                if (_authorRepo == null)
                    _authorRepo = new AuthorRepository(_db);
                return _authorRepo;
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                if (_albumRepo == null)
                    _albumRepo = new AlbumRepository(_db);
                return _albumRepo;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepo == null)
                    _orderRepo = new OrderRepository(_db);
                return _orderRepo;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if(!isDisposed)
            {
                if(disposing)
                {
                    _db.Dispose();
                    
                }
                isDisposed = true;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
