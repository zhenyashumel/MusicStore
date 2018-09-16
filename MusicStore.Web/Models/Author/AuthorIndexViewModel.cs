using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MusicStore.Web.Models.Album;
using MusicStore.Web.Models.Song;

namespace MusicStore.Web.Models.Author
{
    public class AuthorIndexViewModel
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        [Display(Name = "Tracks")]
        public int SongsCount => Songs?.Count ?? 0;
        [Display(Name = "Albums")]
        public int AlbumsCount => Songs?.Count ?? 0;

        public virtual ICollection<SongDetailsViewModel> Songs { get; set; }
        public virtual ICollection<AlbumDetailsViewModel> Albums { get; set; }

        public AuthorIndexViewModel()
        {
            Songs = new List<SongDetailsViewModel>();
            Albums = new List<AlbumDetailsViewModel>();

        }
    }
}