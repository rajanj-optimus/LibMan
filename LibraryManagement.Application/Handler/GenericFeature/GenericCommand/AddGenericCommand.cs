using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.DTO;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Handler.GenericFeature.GenericCommand
{
    public class AddGenericCommand<TEntity, TDto> : IRequest<TDto>
    {
        //private Author author;
        public TDto EntityDto;

        public AddGenericCommand(TDto entityDto)
        {
            this.EntityDto = entityDto;
        }

    }
}
