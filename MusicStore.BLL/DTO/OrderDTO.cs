using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<SongDTO> Songs { get; set; }
        public float Price { get; set; }

        public OrderDTO()
        {
            Date = new DateTime();
            Songs = new List<SongDTO>();
        }
    }
}
