using CA.Domain.Entities;
using CA.Domain.GlobalExceptions;
using CA.Domain.Models.Pages;
using CA.Domain.RepositoryInterfaces;
using CA.Domain.Utilities;
using CA.Extensions;
using CA.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistence.EFRepositories
{
    public class GenericEFRepository<T> : IGenericRepository<T> where T : BasicEntity
    {
        private protected readonly AuctionContext _context = null!;
        private protected readonly DbSet<T> _table = null!;
        public GenericEFRepository(AuctionContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _table.AddAsync(entity!);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new CreatingFailedException();
            }
        }

        public async Task<T> DeleteAsync(T entity)
        {
            try
            {
                _table.Remove(entity!);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new DeletingFailedException();
            }
        }

        public async Task<PagedList<T>> GetAllAsync(PageSettingsModel settings)
        {
            try
            {
                
                var query = _table.AsNoTracking();
                return await PagedList<T>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<T?> GetAsNoTrackingAsync(int id)
        {
            try
            {
                return await _table.AsNoTracking()
                    .WhereIdEquals(m => m.Id, id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<T?> GetAsync(int id)
        {
            try
            {
                return await _table.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _table.Attach(entity!);
                _context.Entry(entity!).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new UpdatingFailedException();
            }
        }
    }
}
