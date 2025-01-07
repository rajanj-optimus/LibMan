﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTO;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Mapper
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookDto,Book>();
        }
    }
}
