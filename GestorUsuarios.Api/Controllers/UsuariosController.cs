using AutoMapper;
using GestorUsuarios.Core.DTOs;
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
        private readonly IMapper mapper;
        public UsuariosController(IUsuarioRepository _usuarioRepository, IMapper _mapper)
        {
            usuarioRepository = _usuarioRepository;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await usuarioRepository.GetUsuarios();
            if (usuarios != null)
            {
                var usuarioDto = mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
                return Ok(usuarioDto);
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
                var usuarioDto = mapper.Map<UsuarioDto>(usuario);
                return Ok(usuarioDto);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostUsuario(UsuarioDto usuarioDto)
        {
            var usuario = mapper.Map<Usuario>(usuarioDto);
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
                var usuarioDto = mapper.Map<UsuarioDto>(usuario);
                return Ok(usuarioDto);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
