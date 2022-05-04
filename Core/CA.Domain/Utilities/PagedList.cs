using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Utilities
{
    public class PagedList<T> : List<T>
    {
        public short CurrentPage { get; private set; }
        public short TotalPages { get; private set; }
        public byte PageSize { get; private set; }
        public byte TotalItemsCount { get; private set; }
        public bool HasPrevPage
        {
            get
            {
                if (TotalPages == 0) return false;
                else if(CurrentPage <= 1) return false;
                return true;
            }
        }
        public bool HasNextPage
        {
            get
            {
                if(TotalPages == 0 || CurrentPage == 0) return false;
                else if (CurrentPage == TotalPages) return false;
                return true;
            }
        }

        public PagedList(List<T> items, short totalPages, byte itemsCount, short currentPage, byte pageSize)
        {
            TotalPages = totalPages;
            TotalItemsCount = itemsCount;
            PageSize = pageSize;
            CurrentPage = currentPage;

            AddRange(items);
        }

        public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> query, short currentPage, byte pageSize)
        {
            var itemsCount = (byte)query.Count();
            var totalPages = (short)Math.Ceiling(itemsCount / (double)pageSize);

            var items = await query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize).ToListAsync();

            return new PagedList<T>(items, totalPages, itemsCount, currentPage, pageSize);
        }
    }
}
