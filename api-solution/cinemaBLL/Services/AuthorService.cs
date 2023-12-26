using AutoMapper;
using Entites.DataTransferObject.AuthorDtos;
using Entites.Models;
using FluentValidation;
using Interfaces.Repositories;
using Interfaces.Services;

namespace cinemaBLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Author> _vaidator;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper, IValidator<Author> validator)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _vaidator = validator;
        }
        public async Task CreateAuthorAsync(AuthorForCreateDto author, CancellationToken cancellationToken = default)
        {
            var authorForCreate = _mapper.Map<Author>(author);

            _vaidator.ValidateAndThrow(authorForCreate);

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

            _vaidator.ValidateAndThrow(authorForUpdate);

            await _authorRepository.UpdateAuthorAsync(authorForUpdate, cancellationToken);
        }
    }
}
