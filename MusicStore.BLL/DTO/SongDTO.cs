using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.BLL.DTO
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        
        public AuthorDTO Author { get; set; }
       
        public AlbumDTO Album { get; set; }
    }
}
