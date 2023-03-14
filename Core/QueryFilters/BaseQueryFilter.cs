using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QueryFilters
{
    public abstract class BaseQueryFilter
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
        public DateTime FchIni { get; set; }
        public DateTime FchFin { get; set; }



        public BaseQueryFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public BaseQueryFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
