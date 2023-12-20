using AutoMapper;
using Entites;
using Entites.DataTransferObject;
using Interfaces.Repositories;
using Interfaces.Services;

namespace cinemaBLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task CreateAuthorAsync(AuthorForCreateDto author, CancellationToken cancellationToken = default)
        {
            var authorForCreate = _mapper.Map<Author>(author);
            await _authorRepository.CreateAuthorAsync(authorForCreate, cancellationToken);
        }
        public async Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
        {
            await _authorRepository.DeleteAuthorAsync(id, cancellationToken);
        }
        public async Task<IEnumerable<AuthorDto>> GetAllAuthorAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<AuthorDto>>(await _authorRepository.GetAllAuthorAsync(cancellationToken));
        }
        public async Task<AuthorDto> GetAuthorByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<AuthorDto>(await _authorRepository.GetAuthorByIdAsync(id, cancellationToken));
        }
        public async Task UpdateAuthorAsync(AuthorForUpdateDto author, CancellationToken cancellationToken = default)
        {
            var authorForUpdate = _mapper.Map<Author>(author);
            await _authorRepository.UpdateAuthorAsync(authorForUpdate, cancellationToken);
        }
    }
}
