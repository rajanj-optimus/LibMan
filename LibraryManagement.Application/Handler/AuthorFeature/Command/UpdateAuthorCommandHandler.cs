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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand,Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorRepository.UpdateAuthorAsync(request.author, request._id);
        }

    }
}
