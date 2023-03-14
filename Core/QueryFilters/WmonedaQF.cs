using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QueryFilters
{
    public class WmonedaQF : BaseQueryFilter
    {
        public int MndId { get; set; }
        public string MndNombre { get; set; }
    }
}
