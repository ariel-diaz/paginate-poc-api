using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginatePOC.Helpers;
using PaginatePOC.Interfaces;
using PaginatePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginatePOC.Services
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext _context;

        public DataRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Item>> GetValues([FromQuery]ParamsPaginate paramsPag)
        {
            var items = _context.Values;

            return await PagedList<Item>.CreateAsync(items, paramsPag.PageNumber, paramsPag.PageSize);
        }
    }
}
