
using MusicStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.EF
{
    public class MusicStoreContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Order> Orders { get; set; }

        public MusicStoreContext(string connectionString):base(connectionString)
        {

        }

        static  MusicStoreContext()
        {
            Database.SetInitializer<MusicStoreContext>(new MusicStoreDatabaseInitializer());
        }
    }
}
