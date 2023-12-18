namespace Entites
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

    }
}
