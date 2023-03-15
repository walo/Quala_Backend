using Core.DTO;
using Core.DTO.Custom;
using Core.Entities;
using Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IServices
{
    public interface IWsucursalService
    {
        Task<CustomResponseDto<WsucursalDto>> GetById(WsucursalQF filter);
        Task<CustomResponseDto<List<WsucursalDto>>> GetAll(WsucursalQF filter);
        Task<CustomResponseDto<List<WsucursalDto>>> GetPaged(WsucursalQF filter);

        Task Add(WsucursalDto dato);
        Task Delete(WsucursalQF filter);
        Task Update(WsucursalQF filter, WsucursalDto dato);
    }
}
