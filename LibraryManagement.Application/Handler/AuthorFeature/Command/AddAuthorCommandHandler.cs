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
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;

        public AddAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = request._author;
            await _authorRepository.AddAuthorAsync(author);
            return Unit.Value;

        }
    }
}
