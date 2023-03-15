using Core.Entities;
using Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IRepository
{
    public interface IWmonedaRepository
    {
        Task<Wmoneda> GetById(WmonedaQF filter);
        Task<List<Wmoneda>> GetAll(WmonedaQF filter);
        Task<List<Wmoneda>> GetPaged(WmonedaQF filter);

        Task Add(Wmoneda dato);
        void Delete(Wmoneda dato);
        void Update(Wmoneda dato);
        
    }
}
