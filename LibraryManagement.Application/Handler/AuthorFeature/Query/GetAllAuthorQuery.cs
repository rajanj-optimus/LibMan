using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.DTO;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.AuthorFeature.Query
{
    public class GetAllAuthorQuery() : IRequest<IEnumerable<Author>>
    {

    }

}
