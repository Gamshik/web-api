using Entites.DataTransferObject.AuthorDtos;

namespace Interfaces.Services
{
    public interface IAuthorService
    {
        Task CreateAuthorAsync(AuthorForCreateDto author, CancellationToken cancellationToken = default);
        Task<IEnumerable<AuthorDto>> GetAllAuthorAsync(CancellationToken cancellationToken = default);
        Task<AuthorDto> GetAuthorByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAuthorAsync(AuthorForUpdateDto author, CancellationToken cancellationToken = default);
        Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    }
}
