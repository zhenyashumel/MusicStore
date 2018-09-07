﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.BLL.DTO
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleasedYear { get; set; }

       
        public AuthorDTO Author { get; set; }

        public virtual ICollection<SongDTO> Songs { get; set; }
        public AlbumDTO()
        {
            Songs = new List<SongDTO>();
        }
    }
}
