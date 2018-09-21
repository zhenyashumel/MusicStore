using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public double Price { get; set; }
        

        public int UserId { get; set; }
        
        public string Description { get; set; }

        public Order()
        {
            Date = new DateTime();
            Songs = new List<Song>();
            Albums = new List<Album>();
        }
    }
}

