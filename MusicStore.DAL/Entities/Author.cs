using System;
using System.Collections;
using System.Collections.Generic;

namespace MusicStore.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public Author()
        {
            Songs = new List<Song>();
            Albums = new List<Album>();

        }



    }
}
