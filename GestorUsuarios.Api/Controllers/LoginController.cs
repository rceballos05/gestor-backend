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
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginRepository;
        private readonly IMapper mapper;
        public LoginController(ILoginRepository _loginRepository, IMapper _mapper)
        {
            loginRepository = _loginRepository;
            mapper = _mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogin(int id)
        {
            var login = await loginRepository.GetLogin(id);
            if (login != null)
            {
                var loginDto = mapper.Map<LoginDto>(login);
                return Ok(loginDto);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("verificarLogin/{usuario}/{contraseña}")]
        public async Task<IActionResult> VerificarLogin(string usuario, string contraseña)
        {
            var login = await loginRepository.VerificarLogin(usuario, contraseña);
            if(login != null)
            {
                var loginDto = mapper.Map<LoginDto>(login);
                return Ok(loginDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
