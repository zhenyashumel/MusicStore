using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Web.Models.Album;
using MusicStore.Web.Models.Author;

namespace MusicStore.Web.Models.Song
{
    public class SongDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public AuthorDetailsViewModel Author { get; set; }
        public int AlbumId { get; set; }
        public AlbumDetailsViewModel Album { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }

    }
}