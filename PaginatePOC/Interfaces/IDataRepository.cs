using Microsoft.AspNetCore.Mvc;
using PaginatePOC.Helpers;
using PaginatePOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginatePOC.Interfaces
{
    public interface IDataRepository
    {

        Task<PagedList<Item>> GetValues(ParamsPaginate paramsPag);
    }
}
