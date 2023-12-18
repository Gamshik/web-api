namespace Entites
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
