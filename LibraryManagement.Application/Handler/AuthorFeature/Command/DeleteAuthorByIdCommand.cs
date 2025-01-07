using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;
using MediatR;
namespace LibraryManagement.Application.Handler.AuthorFeature.Command  
{
    public class DeleteAuthorByIdCommand : IRequest<Author>
    {
        public int _id;

        public DeleteAuthorByIdCommand(int id)
        {
            _id = id;
        }
    }
}
