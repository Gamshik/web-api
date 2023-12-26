namespace Entites.DataTransferObject.AuthorDtos
{
    public class AuthorForUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
