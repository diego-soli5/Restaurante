using AutoMapper;
using Microsoft.AspNetCore.Http;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.Reservacion;
using Restaurante.LogicaNegocio.DTO.Usuario;
using Restaurante.LogicaNegocio.Exceptions;
using Restaurante.LogicaNegocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Restaurante.LogicaNegocio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenServicio;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork unidadDeTrabajo,
                               ITokenService tokenServicio,
                               IPasswordService passwordService,
                               IMapper mapper)
        {
            _unitOfWork = unidadDeTrabajo;
            _tokenServicio = tokenServicio;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public IEnumerable<UsuarioDTO> ObtenerTodo()
        {
            var usuarios = _unitOfWork.Usuario.ObtenerTodo();

            var usuariosDTO = usuarios.ToList().Select(usuario => _mapper.Map<UsuarioDTO>(usuario));
           
            return usuariosDTO;
        }

        public ResultadoLoginDTO IniciarSesion(PeticionLoginDTO peticionLogin)
        {
            var usuario = _unitOfWork.Usuario.ObtenerPorNombreUsuario(peticionLogin.TcNombreUsuario);

            if (usuario == null)
            {
                throw new BusinessException("Nombre de usuario y/o contraseña incorrectos.", StatusCodes.Status401Unauthorized);
            }

            var result = _passwordService.Check(usuario.TcContrasena, peticionLogin.TcContrasena);

            if (!result)
            {
                throw new BusinessException("Nombre de usuario y/o contraseña incorrectos.", StatusCodes.Status401Unauthorized);
            }

            var JWT = _tokenServicio.GenerarJWT(usuario);

            return new ResultadoLoginDTO(JWT.Item1, usuario.Id, usuario.TcNombre, usuario.TcCorreoElectronico);
        }

        public bool Registrar(UsuarioRegistrarDTO usuarioRegistrarDTO)
        {
            var usuario = _mapper.Map<TrestUsuario>(usuarioRegistrarDTO);

            ValidarCampos(usuario);

            if (_unitOfWork.Usuario.ObtenerPorNombreUsuario(usuario.TcNombreUsuario) != null)
            {
                throw new BusinessException("El nombre de usuario ya se encuentra en uso.", StatusCodes.Status400BadRequest);
            }

            if (_unitOfWork.Usuario.ObtenerPorCorreoElectronico(usuario.TcCorreoElectronico) != null)
            {
                throw new BusinessException("El correo electronico ya se encuentra en uso.", StatusCodes.Status400BadRequest);
            }

            usuario.TcContrasena = _passwordService.Hash(usuario.TcContrasena);
            usuario.TbEstado = true;

            _unitOfWork.Usuario.Crear(usuario);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Eliminar(int id)
        {
            var usuario = _unitOfWork.Usuario.ObtenerPorId(id);

            if (usuario == null)
            {
                throw new BusinessException("Usuario no existe.", statusCode: StatusCodes.Status400BadRequest);
            }

            usuario.TbEstado = false;

            _unitOfWork.Usuario.Actualizar(usuario);

            bool result = _unitOfWork.Save();

            return result;
        }

        private bool ValidarCampos(TrestUsuario usuario)
        {

            if (usuario.TcContrasena == null ||
               usuario.TcNombreUsuario == null ||
               usuario.TcNombre == null ||
               usuario.TcCorreoElectronico == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
