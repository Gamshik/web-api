using Entites.DataTransferObject;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Author")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorAsync(CancellationToken cancellationToken = default)
        {
            var authors = await _authorService.GetAllAuthorAsync(cancellationToken);
            return Ok(authors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var author = await _authorService.GetAuthorByIdAsync(id, cancellationToken);
            return Ok(author);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto, CancellationToken cancellationToken = default)
        {
            await _authorService.CreateAuthorAsync(authorForCreateDto, cancellationToken);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync(AuthorForUpdateDto authorForUpdateDto, CancellationToken cancellationToken = default)
        {
            await _authorService.UpdateAuthorAsync(authorForUpdateDto, cancellationToken);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAuthorAsync(int id, CancellationToken cancellationToken)
        {
            await _authorService.DeleteAuthorAsync(id, cancellationToken);
            return Ok();
        }
    }
}
