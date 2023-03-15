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
    public class WmonedaRepository : IWmonedaRepository
    {
        protected readonly DbSet<Wmoneda> _entities;
        private readonly QDbContext _context;

        public WmonedaRepository(QDbContext context)
        {
            _context = context;
            _entities = context.Set<Wmoneda>();
        }

        public async Task Add(Wmoneda dato)
        {
            await _entities.AddAsync(dato);
        }

        public void Delete(Wmoneda dato)
        {
            //_context.Entry(dato).State = EntityState.Deleted;
            //_entities.Attach(dato);
            _entities.Remove(dato);
        }

        public async Task<List<Wmoneda>> GetAll(WmonedaQF filter)
        {
            var data = _entities
                .AsQueryable();
            data = Filtro(data, filter);
            return await data.ToListAsync();
        }

        public async Task<Wmoneda> GetById(WmonedaQF filter)
        {
            var data = _entities
                .AsQueryable();
            data = Filtro(data, filter);
            return await data.FirstOrDefaultAsync();
        }

        public async Task<List<Wmoneda>> GetPaged(WmonedaQF filter)
        {
            var data = _entities
                .AsQueryable();

            data = Filtro(data, filter);

            return await data
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToListAsync();
        }

        public void Update(Wmoneda dato)
        {
            _entities.Update(dato);
        }

        public void UpdateRange(List<Wmoneda> datos)
        {
            _entities.UpdateRange(datos);
        }

        private IQueryable<Wmoneda> Filtro(IQueryable<Wmoneda> data, WmonedaQF filter)
        {
            if (filter.MndId > 0)
                data = data.Where(d => d.MndId == filter.MndId);

            if (!string.IsNullOrEmpty(filter.MndNombre))
                data = data.Where(d => d.MndNombre == filter.MndNombre);

            return data;
        }
    }
}
