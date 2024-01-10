using AutoMapper;
using Microsoft.AspNetCore.Http;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.Mesa;
using Restaurante.LogicaNegocio.Exceptions;
using Restaurante.LogicaNegocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.LogicaNegocio.Services
{
    public class MesaService : IMesaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string _NOEXISTE = "Mesa no existe.";

        public MesaService(IUnitOfWork unitOfWork,
                           IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public MesaDTO ObtenerPorId(int id)
        {
            var mesa = _unitOfWork.Mesa.ObtenerPorId(id);

            if (mesa == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status404NotFound);
            }

            var mesaDTO = _mapper.Map<MesaDTO>(mesa);

            return mesaDTO;
        }

        public IEnumerable<MesaDTO> ObtenerTodo()
        {
            var mesas = _unitOfWork.Mesa.ObtenerTodo();

            var mesasDTO = mesas.Select(mesa => _mapper.Map<MesaDTO>(mesa));

            return mesasDTO;
        }

        public bool Crear(MesaCrearDTO mesaCrearDTO)
        {
            var mesa = _mapper.Map<TrestMesa>(mesaCrearDTO);

            mesa.TbEstado = true;

            ValidarCampos(mesa);

            _unitOfWork.Mesa.Crear(mesa);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Actualizar(MesaDTO mesaDTO, int id)
        {
            var mesa = _unitOfWork.Mesa.ObtenerPorId(id);

            if (mesa == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            mesa.TcDscMesa = mesaDTO.TcDscMesa;

            ValidarCampos(mesa);

            _unitOfWork.Mesa.Actualizar(mesa);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Eliminar(int id)
        {
            var mesa = _unitOfWork.Mesa.ObtenerPorId(id, "TrestReservacion");

            if (mesa == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            if (mesa.TrestReservacion != null)
            {
                if (mesa.TrestReservacion.Where(x => x.TbEstado).Count() > 0)
                {
                    throw new BusinessException("No se puede eliminar, existen reservaciones activas asociadas.", StatusCodes.Status400BadRequest);
                }
            }

            mesa.TbEstado = false;

            _unitOfWork.Mesa.Actualizar(mesa);

            bool result = _unitOfWork.Save();

            return result;
        }

        private bool ValidarCampos(TrestMesa mesa)
        {

            if (mesa.TcDscMesa == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
