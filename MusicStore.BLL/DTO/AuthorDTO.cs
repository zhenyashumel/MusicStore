using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.BLL.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<SongDTO> Songs { get; set; }
        public virtual ICollection<AlbumDTO> Albums { get; set; }

        public AuthorDTO()
        {
            Songs = new List<SongDTO>();
            Albums = new List<AlbumDTO>();

        }
    }
}
