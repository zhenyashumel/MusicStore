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
        public IEnumerable<Song> Songs { get; set; }
        public float Price { get; set; }

        public Order()
        {
            Date = new DateTime();
            Songs = new List<Song>();
        }

    }
}
