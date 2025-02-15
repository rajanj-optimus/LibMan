﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddEntityAsync(T TEntity);
    }
}
