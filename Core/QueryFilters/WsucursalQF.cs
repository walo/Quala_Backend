using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QueryFilters
{
    public class WsucursalQF : BaseQueryFilter
    {
        public int SucCodigo { get; set; }
        public string SucDescripcion { get; set; }
        public string SucIdentificacion { get; set; }
    }
}
