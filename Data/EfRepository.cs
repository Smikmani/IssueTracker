using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Data.Entities;

namespace Project1.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext context;

        public EfRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        
        public async Task<IReadOnlyList<T>> ListAllAsync(int Id)
        {
            
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await context.Set<T>().CountAsync();
        }

    }
}
