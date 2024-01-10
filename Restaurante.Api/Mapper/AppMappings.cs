using AutoMapper;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.Cliente;
using Restaurante.LogicaNegocio.DTO.Menu;
using Restaurante.LogicaNegocio.DTO.Mesa;
using Restaurante.LogicaNegocio.DTO.Reservacion;
using Restaurante.LogicaNegocio.DTO.TipoMenu;
using Restaurante.LogicaNegocio.DTO.Usuario;
using System.Reflection;

namespace Restaurante.LogicaNegocio.Mapper
{
    public class AppMappings : Profile
    {
        public AppMappings()
        {
            Mapear();
        }

        private void Mapear()
        {
            CreateMap<ClienteDTO, TrestCliente>()
               .ReverseMap();

            CreateMap<MenuDTO, TrestMenu>()
               .ReverseMap();

            CreateMap<TrestMenu, MenuDTO>()
               .ForMember(dest => dest.TcDscTipoMenu, opt => opt.MapFrom(src => src.TrestTipomenu.TcDscTipoMenu))
               .ReverseMap();

            CreateMap<MesaDTO, TrestMesa>()
               .ReverseMap();

            CreateMap<ReservacionDTO, TrestReservacion>()
               .ReverseMap();

            CreateMap<TrestReservacion, ReservacionDTO>()
                .ForMember(dest => dest.TcNombre, opt => opt.MapFrom(src => $"{src.TnIdClienteNavigation.TcNombre} {src.TnIdClienteNavigation.TcAp1} {src.TnIdClienteNavigation.TcAp2}"))
                .ForMember(dest => dest.TcDscMesa, opt => opt.MapFrom(src => src.TnIdMesaNavigation.TcDscMesa))
                .ForMember(dest => dest.TcDscMenu, opt => opt.MapFrom(src => src.TnIdMenuNavigation.TcDscMenu))
               .ReverseMap();

            CreateMap<TrestTipomenu, TipoMenuDTO>()
                .ReverseMap();

            CreateMap<TipoMenuDTO, TrestTipomenu>()
                .ReverseMap();

            CreateMap<UsuarioDTO, TrestUsuario>()
               .ReverseMap();

            //

            CreateMap<ClienteCrearDTO, TrestCliente>()
               .ReverseMap();

            CreateMap<MenuCrearDTO, TrestMenu>()
               .ReverseMap();

            CreateMap<MesaCrearDTO, TrestMesa>()
               .ReverseMap();

            CreateMap<ReservacionCrearDTO, TrestReservacion>()
               .ReverseMap();

            CreateMap<TipoMenuCrearDTO, TrestTipomenu>()
               .ReverseMap();

            CreateMap<UsuarioRegistrarDTO, TrestUsuario>()
               .ReverseMap();
        }
    }
}
