using GestorUsuarios.Core.Entities;
using GestorUsuarios.Core.Interfaces;
using GestorUsuarios.Infraestructure.Repositories;
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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuariosController(IUsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await usuarioRepository.GetUsuarios();
            if (usuarios != null)
            {
                return Ok(usuarios);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await usuarioRepository.GetUsuario(id);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuario usuario)
        {
            await usuarioRepository.PostUsuario(usuario);
            return Ok();
        }
        [HttpGet]
        [Route("obtenerUsuarioByLogin/{id}")]
        public async Task<IActionResult> ObtenerUsuarioByLogin(int id)
        {
            var usuario = await usuarioRepository.ObtenerUsuarioByLogin(id);
            if(usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
