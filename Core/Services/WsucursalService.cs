using AutoMapper;
using Core.DTO;
using Core.DTO.Custom;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.IServices;
using Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class WsucursalService : IWsucursalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WsucursalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(WsucursalDto dato)
        {
            var sucursal = _mapper.Map<Wsucursal>(dato);
            await _unitOfWork.WsucursalRepository.Add(sucursal);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CustomResponseDto<List<WsucursalDto>>> GetAll(WsucursalQF filter)
        {
            var data = await _unitOfWork.WsucursalRepository.GetAll(filter);
            var datoDtoResp = _mapper.Map<List<WsucursalDto>>(data);

            CustomResponseDto<List<WsucursalDto>> responseDto = new CustomResponseDto<List<WsucursalDto>>(datoDtoResp)
            {
                Count = datoDtoResp.Count,
                Successful = datoDtoResp.Count > 0,
                Message = datoDtoResp.Count > 0 ? "Datos" : "No hay datos"
            };

            return responseDto;
        }

        public async Task<CustomResponseDto<WsucursalDto>> GetById(WsucursalQF filter)
        {
            var data = await _unitOfWork.WsucursalRepository.GetById(filter);
            var datoDtoResp = _mapper.Map<WsucursalDto>(data);

            CustomResponseDto<WsucursalDto> responseDto = new CustomResponseDto<WsucursalDto>(datoDtoResp)
            {
                Successful = datoDtoResp != null,
                Message = datoDtoResp != null ? "Datos" : "No hay datos"
            };

            return responseDto;
        }

        public async Task<CustomResponseDto<List<WsucursalDto>>> GetPaged(WsucursalQF filter)
        {
            var data = await _unitOfWork.WsucursalRepository.GetPaged(filter);
            var datoDtoResp = _mapper.Map<List<WsucursalDto>>(data);

            CustomResponseDto<List<WsucursalDto>> responseDto = new CustomResponseDto<List<WsucursalDto>>(datoDtoResp)
            {
                Count = datoDtoResp.Count,
                Successful = datoDtoResp.Count > 0,
                Message = datoDtoResp.Count > 0 ? "Datos" : "No hay datos"
            };

            return responseDto;
        }

        public async Task Update(WsucursalQF filter, WsucursalDto dato)
        {
            var sucursal = await _unitOfWork.WsucursalRepository.GetById(filter);
            
            sucursal.SucDescripcion = !string.IsNullOrEmpty(dato.SucDescripcion) ? dato.SucDescripcion.Trim() : sucursal.SucDescripcion.Trim();
            sucursal.SucDireccion = !string.IsNullOrEmpty(dato.SucDireccion) ? dato.SucDireccion.Trim() : sucursal.SucDireccion.Trim();
            sucursal.SucIdentificacion = !string.IsNullOrEmpty(dato.SucIdentificacion) ? dato.SucIdentificacion.Trim() : sucursal.SucIdentificacion.Trim();
            sucursal.MndId = dato.MndId > 0 ? dato.MndId : sucursal.MndId;

            // _unitOfWork.WsucursalRepository.Update(dato);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateRange(WsucursalQF filter, List<Wsucursal> datos)
        {
            _unitOfWork.WsucursalRepository.UpdateRange(datos);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
