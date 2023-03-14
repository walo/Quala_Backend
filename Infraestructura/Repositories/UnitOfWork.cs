using Core.Interfaces;
using Core.Interfaces.IRepository;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QDbContext _context;
        public UnitOfWork(QDbContext context)
        {
            _context = context;
        }

        private readonly IWmonedaRepository _wmonedaRepository;
        private readonly IWsucursalRepository _wsucursalRepository;

        public IWmonedaRepository WmonedaRepository => _wmonedaRepository ?? new WmonedaRepository(_context);

        public IWsucursalRepository WsucursalRepository => _wsucursalRepository ?? new WsucursalRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public bool SaveChanges()
        {
            int rows = _context.SaveChanges();
            return rows > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
