using AutoMapper;
using GestorUsuarios.Core.DTOs;
using GestorUsuarios.Core.Entities;
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
        [Route("obtenerTareas")]
        public async Task<IActionResult> GetTareas()
        {
            var tareas = await tareaRepository.GetTareas();
            var tareasDto = mapper.Map<IEnumerable<TareaDto>>(tareas);
            return Ok(tareasDto);
        }
        [HttpGet]
        [Route("obtenerTareaById/{id}")]
        public async Task<IActionResult> GetTareaById(int id)
        {
            var tarea = await tareaRepository.GetTareaById(id);
            var tareaDto = mapper.Map<TareaDto>(tarea);
            return Ok(tareaDto);
        }
        [HttpGet]
        [Route("obtenerTareasByIdUsuario/{idUsuario}")]
        public async Task<IActionResult> GetTareasByIdUsuario(int idUsuario)
        {
            var tareas = await tareaRepository.GetTareasByIdUsuario(idUsuario);
            var tareasDto = mapper.Map<TareaDto>(tareas);
            return Ok(tareasDto);
        }
        [HttpPost]
        [Route("insertTarea")]
        public async Task<IActionResult> InsertTarea(TareaDto tareaDto)
        {
            var tarea = mapper.Map<Tarea>(tareaDto);
            var response = await tareaRepository.InsertTarea(tarea);
            if(response)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("updateTarea")]
        public async Task<IActionResult> UpdateTarea(TareaDto tareaDto)
        {
            var tarea = mapper.Map<Tarea>(tareaDto);
            var response = await tareaRepository.UpdateTarea(tarea);
            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("terminarTarea")]
        public async Task<IActionResult> TerminarTarea(TareaDto tareaDto)
        {
            var tarea = mapper.Map<Tarea>(tareaDto);
            var response = await tareaRepository.TerminarTarea(tarea);
            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("deleteTarea")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var response = await tareaRepository.DeleteTarea(id);
            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
