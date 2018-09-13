using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Web.Models.Song
{
    public class SongAlbumViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }

    }
}