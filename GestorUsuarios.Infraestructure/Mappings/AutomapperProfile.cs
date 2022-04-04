using AutoMapper;
using GestorUsuarios.Core.DTOs;
using GestorUsuarios.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Login, LoginDto>();
            CreateMap<LoginDto, Login>();
            CreateMap<Tarea, TareaDto>();
            CreateMap<TareaDto, Tarea>();
        }
    }
}
