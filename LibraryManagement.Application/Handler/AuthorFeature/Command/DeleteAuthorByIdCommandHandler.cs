using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Interface;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.AuthorFeature.Command
{
    public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorByIdCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(DeleteAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            return await _authorRepository.DeleteAuthorByIdAsync(request._id);
            
        }
    }
}
