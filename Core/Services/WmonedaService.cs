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
    public class WmonedaService : IWmonedaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WmonedaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(WmonedaDto dato)
        {
            var moneda = _mapper.Map<Wmoneda>(dato);
            await _unitOfWork.WmonedaRepository.Add(moneda);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CustomResponseDto<List<WmonedaDto>>> GetAll(WmonedaQF filter)
        {
            var data = await _unitOfWork.WmonedaRepository.GetAll(filter);
            var datoDtoResp = _mapper.Map<List<WmonedaDto>>(data);

            CustomResponseDto<List<WmonedaDto>> responseDto = new CustomResponseDto<List<WmonedaDto>>(datoDtoResp)
            {
                Count = datoDtoResp.Count,
                Successful = datoDtoResp.Count > 0,
                Message = datoDtoResp.Count > 0 ? "Datos" : "No hay datos"
            };

            return responseDto;
        }

        public async Task<CustomResponseDto<WmonedaDto>> GetById(WmonedaQF filter)
        {
            var data = await _unitOfWork.WmonedaRepository.GetById(filter);
            var datoDtoResp = _mapper.Map<WmonedaDto>(data);

            CustomResponseDto<WmonedaDto> responseDto = new CustomResponseDto<WmonedaDto>(datoDtoResp)
            {
                Successful = datoDtoResp != null,
                Message = datoDtoResp != null ? "Datos" : "No hay datos"
            };

            return responseDto;
        }

        public async Task<CustomResponseDto<List<WmonedaDto>>> GetPaged(WmonedaQF filter)
        {
            var data = await _unitOfWork.WmonedaRepository.GetPaged(filter);
            var datoDtoResp = _mapper.Map<List<WmonedaDto>>(data);

            CustomResponseDto<List<WmonedaDto>> responseDto = new CustomResponseDto<List<WmonedaDto>>(datoDtoResp)
            {
                Count = datoDtoResp.Count,
                Successful = datoDtoResp.Count > 0,
                Message = datoDtoResp.Count > 0 ? "Datos" : "No hay datos"
            };

            return responseDto;
        }

        public async Task Update(WmonedaQF filter, WmonedaDto dato)
        {
            var datoDb = await _unitOfWork.WmonedaRepository.GetById(filter);

            datoDb.MndNombre = !string.IsNullOrEmpty(dato.MndNombre) ? dato.MndNombre.Trim() : datoDb.MndNombre.Trim();

            // _unitOfWork.WmonedaRepository.Update(dato);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task UpdateRange(List<Wmoneda> datos)
        {
            throw new NotImplementedException();
        }
    }
}
