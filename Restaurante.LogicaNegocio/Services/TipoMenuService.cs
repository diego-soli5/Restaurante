using AutoMapper;
using Microsoft.AspNetCore.Http;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.TipoMenu;
using Restaurante.LogicaNegocio.Exceptions;
using Restaurante.LogicaNegocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.LogicaNegocio.Services
{
    public class TipoMenuService : ITipoMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string _NOEXISTE = "Tipo de menu no existe.";

        public TipoMenuService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TipoMenuDTO ObtenerPorId(int id)
        {
            var tipoMenu = _unitOfWork.TipoMenu.ObtenerPorId(id);

            if (tipoMenu == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status404NotFound);
            }

            var tipoMenuDTO = _mapper.Map<TipoMenuDTO>(tipoMenu);

            return tipoMenuDTO;
        }

        public IEnumerable<TipoMenuDTO> ObtenerTodo()
        {
            var tipoMenus = _unitOfWork.TipoMenu.ObtenerTodo();

            var tipoMenuDTO = tipoMenus.Select(tipoMenu => _mapper.Map<TipoMenuDTO>(tipoMenu));

            return tipoMenuDTO;
        }

        public bool Crear(TipoMenuCrearDTO tipoMenuCrearDTO)
        {
            var tipoMenu = _mapper.Map<TrestTipomenu>(tipoMenuCrearDTO);

            tipoMenu.TbEstado = true;

            ValidarCampos(tipoMenu);

            _unitOfWork.TipoMenu.Crear(tipoMenu);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Actualizar(TipoMenuDTO tipoMenuDTO, int id)
        {
            var tipoMenu = _unitOfWork.TipoMenu.ObtenerPorId(id);

            if (tipoMenu == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            tipoMenu.TcDscTipoMenu = tipoMenuDTO.TcDscTipoMenu;

            ValidarCampos(tipoMenu);

            _unitOfWork.TipoMenu.Actualizar(tipoMenu);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Eliminar(int id)
        {
            var tipoMenu = _unitOfWork.TipoMenu.ObtenerPorId(id, "TrestMenu");

            if (tipoMenu == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            if (tipoMenu.TrestMenu != null)
            {
                if (tipoMenu.TrestMenu.Where(x => x.TbEstado).Count() > 0)
                {
                    throw new BusinessException("No se puede eliminar, existen menus activos asociados.", StatusCodes.Status400BadRequest);
                }
            }

            tipoMenu.TbEstado = false;

            _unitOfWork.TipoMenu.Actualizar(tipoMenu);

            bool result = _unitOfWork.Save();

            return result;
        }

        private bool ValidarCampos(TrestTipomenu tipoMenu)
        {

            if (tipoMenu.TcDscTipoMenu == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
