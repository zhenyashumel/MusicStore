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
        public IEnumerable<AlbumDTO> Albums { get; set; }
        public double Price => Songs.Sum(p => p.Price);
        public int UserId { get; set; }
        public string Description { get; set; }

        public OrderDTO()
        {
            Date = new DateTime();
            Songs = new List<SongDTO>();
            Albums = new List<AlbumDTO>();
        }
    }
}
