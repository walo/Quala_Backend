using Core.DTO;
using Core.Interfaces.IServices;
using Core.QueryFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly IWmonedaService _service;

        public MonedaController(IWmonedaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] WmonedaQF filter)
        {
            var data = await _service.GetById(filter);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] WmonedaQF filter)
        {
            var data = await _service.GetAll(filter);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetPaged")]
        public async Task<IActionResult> GetPaged([FromQuery] WmonedaQF filter)
        {
            var data = await _service.GetPaged(filter);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WmonedaDto data)
        {
            await _service.Add(data);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] WmonedaQF filter, [FromBody] WmonedaDto data)
        {
            await _service.Update(filter, data);
            return Ok(data);
        }
    }
}
