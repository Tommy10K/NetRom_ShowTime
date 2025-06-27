using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowTime.DataAccess.Repositories.Abstractions;
using ShowTime.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ShowTime.DataAccess.Repositories.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ShowTimeDbContext context;
        private readonly DbSet<T> entities;

        public GenericRepository(ShowTimeDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task <T?> getByID(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task deleteByID(int id)
        {
            var entity = await getByID(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Entity not found.");
            }
            entities.Remove(entity);
        }

        public async Task add(T entity)
        {
            await entities.AddAsync(entity);
        }

        public async Task update(T entity)
        {
            entities.Update(entity);
            await Task.CompletedTask;
        }
    }
}
