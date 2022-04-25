﻿using CA.Domain.Entities;
using CA.Domain.GlobalExceptions;
using CA.Domain.Models.Pages;
using CA.Domain.RepositoryInterfaces;
using CA.Domain.Utilities;
using CA.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistence.EFRepositories
{
    public class BidsEFRepository : IBidsRepository
    {
        private readonly AuctionContext _context;
        internal BidsEFRepository(AuctionContext context) => _context = context;

        public async Task<bool> AddAsync(Bid entity)
        {
            try
            {
                _context.Add(entity!);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new CreatingFailedException();
            }
        }

        public async Task<bool> DeleteAsync(Bid entity)
        {
            try
            {
                _context.Remove(entity!);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new DeletingFailedException();
            }
        }

        public async Task<PagedList<Bid>> GetAllAsync(PageSettingsModel settings)
        {
            try
            {
                var query = _context.Bids.AsNoTracking();
                return await PagedList<Bid>.ToPagedListAsync(query, settings.SelectedPage, settings.PageSize);
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Bid?> GetAsNoTracking(int id)
        {
            try
            {
                return await _context.Bids
                    .AsNoTracking()
                    .Where(e => e.Id == id)
                    .Include(e => e.Lot)
                    .Include(e => e.User)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }

        public async Task<Bid?> GetAsync(int id)
        {
            try
            {
                return await _context.Bids
                    .Where(e => e.Id == id)
                    .Include(e => e.Lot)
                    .Include(e => e.User)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e.Message);
            }
        }
    }
}
