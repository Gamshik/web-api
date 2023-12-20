namespace Entites.DataTransferObject
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int? AuthorId { get; set; }
        public AuthorDto? Author { get; set; }
    }
}
