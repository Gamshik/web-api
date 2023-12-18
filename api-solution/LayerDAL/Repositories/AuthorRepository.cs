﻿using Entites;
using Entites.Exeptions;
using Interfaces.Repositories;
using LayerDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace LayerDAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly CinemaContext _context;
        public AuthorRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task CreateAuthorAsync(Author author, CancellationToken cancellationToken = default)
        {
            await _context.Authors.AddAsync(author, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
        {
            var authorForDelete = await _context.Authors.SingleOrDefaultAsync(author => author.Id == id, cancellationToken);
            if (authorForDelete == null)
            {
                throw new NotFoundException("Not found Author for delete");
            }

            _context.Authors.Remove(authorForDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<IEnumerable<Author>> GetAllAuthorAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Authors.ToListAsync(cancellationToken);
        }
        public async Task<Author?> GetAuthorByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Authors.SingleOrDefaultAsync(a => a.Id == id, cancellationToken);
        }
        public async Task UpdateAuthorAsync(Author author, CancellationToken cancellationToken = default)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}