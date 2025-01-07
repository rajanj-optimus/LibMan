using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Interface;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.AuthorFeature.Query
{
    //public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    //{

    //    IAuthorRepository _authorRepository;

    //    public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
    //    {
    //        _authorRepository = authorRepository;
    //    }

    //    public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        int id = request._id;
    //        return await _authorRepository.GetAuthorByIdAsync(id);
    //        //return await _authorRepository.GetByIdAsync(id);

    //    }
    //}
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {

        private readonly IGenericRepository<Author> _authorRepository;

        public GetAuthorByIdQueryHandler(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            int id = request._id;
            return await _authorRepository.GetByIdAsync(id);
            //return await _authorRepository.GetByIdAsync(id);

        }
    }
}
