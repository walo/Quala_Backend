using Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IWmonedaRepository WmonedaRepository { get; }

        IWsucursalRepository WsucursalRepository { get; }

        bool SaveChanges();

        Task<bool> SaveChangesAsync();
    }
}
