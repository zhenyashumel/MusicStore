using MusicStore.Web.Models.Author;
using MusicStore.Web.Models.Song;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MusicStore.Web.Models.Album
{
    public class AlbumIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public AuthorAlbumViewModel Author { get; set; }
        public int ReleasedYear { get; set; }

        public ICollection<SongDetailsViewModel> Songs { get; set; }
        [Display(Name ="Tracks")]
        public int SongsCount => Songs?.Count ?? 0;
        [Display(Name = "Duration")]
        public TimeSpan TotalDuration
        {
            get
            {
                if (Songs == null || Songs.Count == 0)
                    return new TimeSpan(0, 0, 0);
                return new TimeSpan(0, 0, Convert.ToInt32(Songs.Sum(p => p.Duration.TotalSeconds)));
            }
        }
        [Display(Name = "Price")]
        public double TotalPrice
        {
            get
            {
                if (Songs == null)
                    return 0d;
                return Songs.Sum(p => p.Price);
            }
        }

        public AlbumIndexViewModel()
        {
            Songs = new List<SongDetailsViewModel>();
        }
    }
}