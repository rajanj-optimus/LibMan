using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.DTO;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Interface
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        //Task<Author> GetAuthorByIdAsync(int id);
        Task<Unit> AddAuthorAsync(Author author);
        Task<Author> DeleteAuthorByIdAsync(int id);
        Task<Author> UpdateAuthorAsync(Author author, int id);

    }
}
