using AutoMapper;
using GestorUsuarios.Core.DTOs;
using GestorUsuarios.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorUsuarios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaRepository tareaRepository;
        private readonly IMapper mapper;
        public TareaController(ITareaRepository _tareaRepository, IMapper _mapper)
        {
            tareaRepository = _tareaRepository;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetTareas()
        {
            var tareas = await tareaRepository.GetTareas();
            var tareasDto = mapper.Map<IEnumerable<TareaDto>>(tareas);
            return Ok(tareasDto);
        }
    }
}
