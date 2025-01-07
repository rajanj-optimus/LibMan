using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.AuthorFeature.Query
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public int _id;

        public GetAuthorByIdQuery(int id)
        {
            _id = id;
        }
    }

    //public
}
