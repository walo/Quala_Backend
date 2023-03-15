using Core.Entities;
using Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IRepository
{
    public interface IWsucursalRepository
    {
        Task<Wsucursal> GetById(WsucursalQF filter);
        Task<List<Wsucursal>> GetAll(WsucursalQF filter);
        Task<List<Wsucursal>> GetPaged(WsucursalQF filter);

        Task Add(Wsucursal dato);
        void Delete(Wsucursal dato);
        void Update(Wsucursal dato);
    }
}
