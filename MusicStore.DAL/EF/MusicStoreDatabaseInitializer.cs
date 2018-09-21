using MusicStore.DAL.Entities;
using System.Data.Entity;
using System;

namespace MusicStore.DAL.EF
{
    public class MusicStoreDatabaseInitializer: DropCreateDatabaseAlways<MusicStoreContext>
    {
        protected override void Seed(MusicStoreContext context)
        {
            Author marilynManson = new Author()
            {
                FirstName = "Bryan",
                LastName = "Warner",
                Age = 49,
                Nickname = "Marilyn Manson",
                Photo = "",
                Bio = "American industrial-rock singer"
            };
           

            Album goldenAge = new Album()
            {
                Author = marilynManson,
                ReleasedYear = 2003,
                Title = "Golden Age of GroteSque"
                
            };

           

            Song thaeter = new Song()
            {
                
                Author = marilynManson,
                Duration = new TimeSpan(0, 1, 14),
                Price = 5,
                Title = "Thaeter",
                Album = goldenAge
            };

            Song gold = new Song()
            {
                Title = "Golden Age of GroteSque",
                Author = marilynManson,
                Duration = new TimeSpan(0, 4, 42),
                Price = 7,
                Album = goldenAge
            };

            context.Authors.Add(marilynManson);
            context.Songs.Add(thaeter);
            context.Albums.Add(goldenAge);
            context.Songs.Add(gold);
            context.SaveChanges();


        }
    }
}
