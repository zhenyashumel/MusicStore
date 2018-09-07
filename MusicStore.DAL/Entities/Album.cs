using System.Collections.Generic;


namespace MusicStore.DAL.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleasedYear { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public Album()
        {
            Songs = new List<Song>();
        }

    }
}
