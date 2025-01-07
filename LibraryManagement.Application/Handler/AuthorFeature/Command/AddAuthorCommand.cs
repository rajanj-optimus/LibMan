using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.DTO;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.AuthorFeature.Command
{
    public class AddAuthorCommand : IRequest<Unit>
    {
        //private Author author;
        public Author _author;

        public AddAuthorCommand(Author author)
        {
            _author = author;
        }

    }
}
