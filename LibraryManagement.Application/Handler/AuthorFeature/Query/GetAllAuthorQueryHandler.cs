using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.DTO;
using LibraryManagement.Application.Interface;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.AuthorFeature.Query
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Author>>
    {
        IAuthorRepository _authorRepository;

        public GetAllAuthorQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<IEnumerable<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }
    }
}
