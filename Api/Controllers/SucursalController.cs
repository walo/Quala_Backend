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
    public class SucursalController : ControllerBase
    {
        private readonly IWsucursalService _service;

        public SucursalController(IWsucursalService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] WsucursalQF filter)
        {
            var data = await _service.GetById(filter);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] WsucursalQF filter)
        {
            var data = await _service.GetAll(filter);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetPaged")]
        public async Task<IActionResult> GetPaged([FromQuery] WsucursalQF filter)
        {
            var data = await _service.GetPaged(filter);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WsucursalDto data)
        {
            await _service.Add(data);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] WsucursalQF filter, [FromBody] WsucursalDto data)
        {
            await _service.Update(filter, data);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] WsucursalQF filter)
        {
            await _service.Delete(filter);
            return Ok(filter);
        }
    }
}
