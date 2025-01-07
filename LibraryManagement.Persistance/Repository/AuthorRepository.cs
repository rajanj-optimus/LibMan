using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTO;
using LibraryManagement.Application.Interface;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Persistance.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly AppDbContext _dbContext;
        //private readonly IMapper mapper;

        public AuthorRepository(AppDbContext dbContex) : base(dbContex)
        {
            this._dbContext = dbContex;
        }
        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
           var data = await _dbContext.Authors.ToListAsync();
           //var returnData = mapper.Map<IEnumerable<AuthorDto>>(data);
           return data;
        }

        //public async Task<Author> GetAuthorByIdAsync(int id)
        //{
        //    var data = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        //    //var returnData = mapper.Map<AuthorDto>(data);
        //    return data;
        //}
        public async Task<Unit> AddAuthorAsync(Author author)
        {
            
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Author> DeleteAuthorByIdAsync(int id)
        {
            var data = await _dbContext.Authors.FindAsync(id);
            //if (data == null)
            //{
            //    // Handle the case where the author was not found
            //    throw new ArgumentException($"Author with id {id} not found.");
            //}
            _dbContext.Authors.Remove(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }

        public async Task<Author> UpdateAuthorAsync(Author author, int id)
        {
            var data = await _dbContext.Authors.FindAsync(id);
            var data2 = new Author { Name = data.Name,Id = data.Id};
            if (data != null)
            {
                data.Name = author.Name;
                await _dbContext.SaveChangesAsync();
                Console.WriteLine(data.Name);
                Console.WriteLine(data2.Name);
                return data2;
            }
            throw new Exception($"Author  not found.");
        }
    }
}
