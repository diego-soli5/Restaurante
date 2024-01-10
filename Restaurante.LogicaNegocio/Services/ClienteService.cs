using AutoMapper;
using Microsoft.AspNetCore.Http;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.Cliente;
using Restaurante.LogicaNegocio.Exceptions;
using Restaurante.LogicaNegocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.LogicaNegocio.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string _NOEXISTE = "Cliente no existe.";

        public ClienteService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ClienteDTO ObtenerPorId(int id)
        {
            var cliente = _unitOfWork.Cliente.ObtenerPorId(id);

            if (cliente == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status404NotFound);
            }

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return clienteDTO;
        }

        public IEnumerable<ClienteDTO> ObtenerTodo()
        {
            var clientes = _unitOfWork.Cliente.ObtenerTodo();

            var clientesDTO = clientes.Select(cliente => _mapper.Map<ClienteDTO>(cliente));

            return clientesDTO;
        }

        public bool Crear(ClienteCrearDTO clienteCrearDTO)
        {
            var cliente = _mapper.Map<TrestCliente>(clienteCrearDTO);

            cliente.TbEstado = true;

            ValidarCampos(cliente);

            _unitOfWork.Cliente.Crear(cliente);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Actualizar(ClienteDTO clienteDTO, int id)
        {
            var cliente = _unitOfWork.Cliente.ObtenerPorId(id);

            if (cliente == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            cliente.TcNombre = clienteDTO.TcNombre;
            cliente.TcAp1 = clienteDTO.TcAp1;
            cliente.TcAp2 = clienteDTO.TcAp2;
            cliente.TcCorreoElectronico = clienteDTO.TcCorreoElectronico;
            cliente.TcNumTelefono = clienteDTO.TcNumTelefono;

            ValidarCampos(cliente);

            _unitOfWork.Cliente.Actualizar(cliente);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Eliminar(int id)
        {
            var cliente = _unitOfWork.Cliente.ObtenerPorId(id, "TrestReservacion");

            if (cliente == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            if (cliente.TrestReservacion != null)
            {
                if (cliente.TrestReservacion.Where(x => x.TbEstado).Count() > 0)
                {
                    throw new BusinessException("No se puede eliminar, existen reservaciones activas asociadas.", StatusCodes.Status400BadRequest);
                }
            }

            cliente.TbEstado = false;

            _unitOfWork.Cliente.Actualizar(cliente);

            bool result = _unitOfWork.Save();

            return result;
        }

        private bool ValidarCampos(TrestCliente cliente)
        {

            if (cliente.TcNombre == null ||
               cliente.TcAp1 == null ||
               cliente.TcAp2 == null ||
               cliente.TcNumTelefono == null ||
               cliente.TcCorreoElectronico == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
