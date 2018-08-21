﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginatePOC.Model
{
    public class ParamsPaginate
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;

        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
