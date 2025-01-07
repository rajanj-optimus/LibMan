using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Interface;
using MediatR;

namespace LibraryManagement.Application.Handler.GenericFeature.GenericQuery
{
    public class GetByIdGenericQueryHandler<T> : IRequestHandler<GetByIdGenericQuery<T>, T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GetByIdGenericQueryHandler(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }


        public async Task<T> Handle(GetByIdGenericQuery<T> request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(request._id);
        }
    }
}
