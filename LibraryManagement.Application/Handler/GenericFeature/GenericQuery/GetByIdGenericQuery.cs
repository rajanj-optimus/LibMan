using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagement.Application.Handler.GenericFeature.GenericQuery
{
    public class GetByIdGenericQuery<T> : IRequest<T> where T : class
    {
        public int _id;
        public GetByIdGenericQuery(int id)
        {
            _id = id;
        }
    }
}
