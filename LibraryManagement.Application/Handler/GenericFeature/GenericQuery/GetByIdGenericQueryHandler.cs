using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Interface;
using MediatR;

namespace LibraryManagement.Application.Handler.GenericFeature.GenericQuery
{
    public class AddGenericCommandHandler<T> : IRequestHandler<GetByIdGenericQuery<T>, T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        public AddGenericCommandHandler(IGenericRepository<T> genericRepository)
        {
            Console.WriteLine("request handler 1");
            _genericRepository = genericRepository;
        }


        public async Task<T> Handle(GetByIdGenericQuery<T> request, CancellationToken cancellationToken)
        {
            Console.WriteLine("request handler 2");

            return await _genericRepository.GetByIdAsync(request._id);
        }
    }
}
