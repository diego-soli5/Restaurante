using AutoMapper;
using Microsoft.AspNetCore.Http;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.Menu;
using Restaurante.LogicaNegocio.Exceptions;
using Restaurante.LogicaNegocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.LogicaNegocio.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string _NOEXISTE = "Menu no existe.";

        public MenuService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public MenuDTO ObtenerPorId(int id)
        {
            var menu = _unitOfWork.Menu.ObtenerPorId(id);

            if (menu == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status404NotFound);
            }

            var menuDTO = _mapper.Map<MenuDTO>(menu);

            return menuDTO;
        }

        public IEnumerable<MenuDTO> ObtenerTodo()
        {
            var menus = _unitOfWork.Menu.ObtenerTodo("TrestTipomenu");

            var menusDTO = menus.Select(menu => _mapper.Map<MenuDTO>(menu));

            return menusDTO;
        }

        public bool Crear(MenuCrearDTO menuCrearDTO)
        {
            var menu = _mapper.Map<TrestMenu>(menuCrearDTO);

            string entidadValidacion = ValidarExistenciaEntidadesForaneas(menu);

            if (entidadValidacion != null)
            {
                throw new BusinessException($"{entidadValidacion} no existe.", StatusCodes.Status400BadRequest);
            }

            menu.TbEstado = true;

            ValidarCampos(menu);

            _unitOfWork.Menu.Crear(menu);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Actualizar(MenuDTO menuDTO, int id)
        {
            var menu = _unitOfWork.Menu.ObtenerPorId(id);

            if (menu == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            menu.TcDscMenu = menuDTO.TcDscMenu;
            menu.TnIdTipoMenu = menuDTO.TnIdTipoMenu;
            menu.TdPrecio = menuDTO.TdPrecio;

            string entidadValidacion = ValidarExistenciaEntidadesForaneas(menu);

            if (entidadValidacion != null)
            {
                throw new BusinessException($"{entidadValidacion} no existe.", StatusCodes.Status400BadRequest);
            }

            ValidarCampos(menu);

            _unitOfWork.Menu.Actualizar(menu);

            bool result = _unitOfWork.Save();

            return result;
        }

        public bool Eliminar(int id)
        {
            var menu = _unitOfWork.Menu.ObtenerPorId(id);

            if (menu == null)
            {
                throw new BusinessException(_NOEXISTE, StatusCodes.Status400BadRequest);
            }

            menu.TbEstado = false;

            _unitOfWork.Menu.Actualizar(menu);

            bool result = _unitOfWork.Save();

            return result;
        }

        private string ValidarExistenciaEntidadesForaneas(TrestMenu menu)
        {
            if (_unitOfWork.TipoMenu.ObtenerPorId(menu.TnIdTipoMenu) == null)
            {
                return "Tipo de menu";
            }

            return null;
        }

        private bool ValidarCampos(TrestMenu menu)
        {
            if (menu.TcDscMenu == null)
            {
                throw new BusinessException("Todos los campos son obligatorios.", StatusCodes.Status400BadRequest);
            }

            return true;
        }
    }
}
