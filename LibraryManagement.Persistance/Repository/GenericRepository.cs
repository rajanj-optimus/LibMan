using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Interface;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task<T> AddEntityAsync(T TEntity)
        {

            await _dbSet.AddAsync(TEntity);
            await _dbContext.SaveChangesAsync();
            return TEntity;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _dbSet.FindAsync(id);
            Console.WriteLine("genric repository");
            return data;
        }
    }
}
