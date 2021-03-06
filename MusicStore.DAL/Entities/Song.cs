﻿using System;
using System.Collections.Generic;


namespace MusicStore.DAL.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Song()
        {
            Orders = new List<Order>();
        }


    }
}
