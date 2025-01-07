using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.Interface;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.GenericFeature.GenericCommand
{
    public class AddGenericCommandHandler<TEntity, TDto> : IRequestHandler<AddGenericCommand<TEntity, TDto>, TDto> where TEntity : class where TDto : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;

        public AddGenericCommandHandler(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        //public async Task<Unit> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        //{
        //    Author author = _mapper.Map<Author>(request.authorDto);
        //    await _authorRepository.AddAuthorAsync(author);
        //    return Unit.Value;
        //}

        public async Task<TDto> Handle(AddGenericCommand<TEntity, TDto> request, CancellationToken cancellationToken)
        {
            TEntity author = _mapper.Map<TEntity>(request.EntityDto);
            TEntity data = await _genericRepository.AddEntityAsync(author);
            return _mapper.Map<TDto>(data);
        }
    }
}
