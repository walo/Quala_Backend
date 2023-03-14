using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class Wsucursal
    {
        public int SucCodigo { get; set; }
        public string SucDescripcion { get; set; }
        public string SucDireccion { get; set; }
        public string SucIdentificacion { get; set; }
        public int MndId { get; set; }
        public DateTime SucFchReg { get; set; }

        public virtual Wmoneda Mnd { get; set; }
    }
}
