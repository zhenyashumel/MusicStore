using MusicStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Song> Songs { get; }
        IRepository<Author> Authors { get; }
        IRepository<Album> Albums { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
