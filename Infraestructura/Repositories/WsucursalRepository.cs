using Core.Entities;
using Core.Interfaces.IRepository;
using Core.QueryFilters;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class WsucursalRepository : IWsucursalRepository
    {
        protected readonly DbSet<Wsucursal> _entities;

        public WsucursalRepository(QDbContext context)
        {
            _entities = context.Set<Wsucursal>();
        }

        public async Task Add(Wsucursal dato)
        {
            await _entities.AddAsync(dato);
        }

        public async Task<List<Wsucursal>> GetAll(WsucursalQF filter)
        {
            var data = _entities
                .Include(x => x.Mnd)
                .AsQueryable();
            data = Filtro(data, filter);
            return await data.ToListAsync();
        }

        public async Task<Wsucursal> GetById(WsucursalQF filter)
        {
            var data = _entities
                .Include(x => x.Mnd)
                .AsQueryable();
            data = Filtro(data, filter);
            return await data.FirstOrDefaultAsync();
        }

        public async Task<List<Wsucursal>> GetPaged(WsucursalQF filter)
        {
            var data = _entities
                .Include(x => x.Mnd)
                .AsQueryable();

            data = Filtro(data, filter);

            return await data
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();
        }

        public void Update(Wsucursal dato)
        {
            _entities.Update(dato);
        }

        public void UpdateRange(List<Wsucursal> datos)
        {
            _entities.UpdateRange(datos);
        }

        public void Delete(Wsucursal dato)
        {
            //_context.Entry(dato).State = EntityState.Deleted;
            //_entities.Attach(dato);
            _entities.Remove(dato);
        }

        private IQueryable<Wsucursal> Filtro(IQueryable<Wsucursal> data, WsucursalQF filter)
        {
            if (filter.SucCodigo > 0)
                data = data.Where(d => d.SucCodigo == filter.SucCodigo);

            if (!string.IsNullOrEmpty(filter.SucDescripcion))
                data = data.Where(d => d.SucDescripcion == filter.SucDescripcion);

            if(filter.MndId > 0)
                data = data.Where(d => d.MndId == filter.MndId);

            return data;
        }
    }
}
