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
        public TareaController(ITareaRepository _tareaRepository)
        {
            tareaRepository = _tareaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetTareas()
        {
            var tareas = await tareaRepository.GetTareas();
            return Ok(tareas);
        }
    }
}
