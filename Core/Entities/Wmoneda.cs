using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class Wmoneda
    {
        public Wmoneda()
        {
            Wsucursals = new HashSet<Wsucursal>();
        }

        public int MndId { get; set; }
        public string MndNombre { get; set; }
        public DateTime MndFchReg { get; set; }

        public virtual ICollection<Wsucursal> Wsucursals { get; set; }
    }
}
