using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.AuthorFeature.Command
{
    public class UpdateAuthorCommand : IRequest<Author>
    {
        public Author author;
        public int _id;

        public UpdateAuthorCommand(Author author, int id)
        {
            this.author = author;
            _id = id;
        }
    }
}
