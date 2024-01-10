using AutoMapper;
using Microsoft.AspNetCore.Http;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.Reservacion;
using Restaurante.LogicaNegocio.Exceptions;
using Restaurante.LogicaNegocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.LogicaNegocio.Services
{
    public class ReservacionService : IReservacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string _NOEXISTE = "Reservacion no existe.";

        public ReservacionService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ReservacionDTO ObtenerPorId(int id)
        {
            var reservacion = _unitOfWork.Reservacion.ObtenerPorId(id);

            if (reservacion == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status404NotFound);
            }

            var reservacionDTO = _mapper.Map<ReservacionDTO>(reservacion);

            return reservacionDTO;
        }

        public IEnumerable<ReservacionDTO> ObtenerTodo()
        {
            var reservaciones = _unitOfWork.Reservacion.ObtenerTodo($"{nameof(TrestReservacion.TnIdMesaNavigation)},{nameof(TrestReservacion.TnIdMenuNavigation)},{nameof(TrestReservacion.TnIdClienteNavigation)}");

            var reservacionsDTO = reservaciones.Select(reservacion => _mapper.Map<ReservacionDTO>(reservacion));

            return reservacionsDTO;
        }

        public bool Crear(ReservacionCrearDTO reservacionCrearDTO)
        {
            var reservacion = _mapper.Map<TrestReservacion>(reservacionCrearDTO);

            string entidadValidacion = ValidarExistenciaEntidadesForaneas(reservacion);

            if (entidadValidacion != null)
            {
                throw new BusinessException($"{entidadValidacion} no existe.", StatusCodes.Status400BadRequest);
            }

            reservacion.TbEstado = true;

            ValidarCampos(reservacion);

            ValidarExistenciaReservacion(reservacion);

            _unitOfWork.Reservacion.Crear(reservacion);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Actualizar(ReservacionDTO reservacionDTO, int id)
        {
            var reservacion = _unitOfWork.Reservacion.ObtenerPorId(id);

            if (reservacion == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            reservacion.TnIdCliente = reservacionDTO.TnIdCliente;
            reservacion.TnIdMesa = reservacionDTO.TnIdMesa;
            reservacion.TnIdMenu = reservacionDTO.TnIdMenu;
            reservacion.TnCantidad = reservacionDTO.TnCantidad;
            reservacion.TfFecReserva = reservacionDTO.TfFecReserva;

            string entidadValidacion = ValidarExistenciaEntidadesForaneas(reservacion);

            if (entidadValidacion != null)
            {
                throw new BusinessException($"{entidadValidacion} no existe.", StatusCodes.Status400BadRequest);
            }

            ValidarCampos(reservacion);

            ValidarExistenciaReservacion(reservacion);
            
            _unitOfWork.Reservacion.Actualizar(reservacion);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Eliminar(int id)
        {
            var reservacion = _unitOfWork.Reservacion.ObtenerPorId(id);

            if (reservacion == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            reservacion.TbEstado = false;

            _unitOfWork.Reservacion.Actualizar(reservacion);

            bool result = _unitOfWork.Save();

            return result;
        }

        private void ValidarExistenciaReservacion(TrestReservacion reservacion)
        {
            if (_unitOfWork.Reservacion.ValidarExistenciaReservacion(reservacion) != null)
            {
                throw new BusinessException("No se puede reservar, ya existe una reservación para la fecha y mesa indicada.", StatusCodes.Status400BadRequest);
            }
        }

        private string ValidarExistenciaEntidadesForaneas(TrestReservacion reservacion)
        {
            if (_unitOfWork.Cliente.ObtenerPorId(reservacion.TnIdCliente) == null)
            {
                return "Cliente";
            }

            if (_unitOfWork.Mesa.ObtenerPorId(reservacion.TnIdMesa) == null)
            {
                return "Mesa";
            }

            if (_unitOfWork.Menu.ObtenerPorId(reservacion.TnIdMenu) == null)
            {
                return "Menu";
            }

            return null;
        }

        private bool ValidarCampos(TrestReservacion reservacion)
        {

            if (reservacion.TnCantidad < 0)
            {
                throw new BusinessException("La cantidad debe ser mayor que 0.", StatusCodes.Status400BadRequest);
            }

            if (reservacion.TfFecReserva.Date <= DateTime.Now.AddDays(-1).Date)
            {
                throw new BusinessException("La fecha no puede ser menor a la actual.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
