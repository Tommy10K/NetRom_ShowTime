﻿using System;
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
        private readonly ShowTimeDbContext _context;

        public GenericRepository(ShowTimeDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity with ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all entities.", ex);
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the entity.", ex);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the entity.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {id} not found.");
                }
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the entity with ID {id}.", ex);
            }
        }
    }
}
