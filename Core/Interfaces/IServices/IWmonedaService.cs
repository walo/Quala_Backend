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
    public interface IWmonedaService
    {
        Task<CustomResponseDto<WmonedaDto>> GetById(WmonedaQF filter);
        Task<CustomResponseDto<List<WmonedaDto>>> GetAll(WmonedaQF filter);
        Task<CustomResponseDto<List<WmonedaDto>>> GetPaged(WmonedaQF filter);

        Task Add(WmonedaDto dato);
        Task Delete(WmonedaQF filter);
        Task Update(WmonedaQF filter, WmonedaDto dato);
    }
}
