namespace Entites.DataTransferObject
{
    public class MovieForCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int? AuthorId { get; set; }
    }
}
