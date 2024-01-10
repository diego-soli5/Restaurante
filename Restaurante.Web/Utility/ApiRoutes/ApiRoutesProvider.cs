namespace Restaurante.Web.Utility.ApiRoutes
{
    public class ApiRoutesProvider
    {
        private readonly ClienteRoutes _clienteRoutes;
        private readonly ReservacionRoutes _reservacionRoutes;
        private readonly MenuRoutes _menuRoutes;
        private readonly TipoMenuRoutes _tipoMenuRoutes;
        private readonly MesaRoutes _mesaRoutes;
        private readonly UsuarioRoutes _usuarioRoutes;

        public ApiRoutesProvider(ClienteRoutes clienteRoutes,
                                 ReservacionRoutes reservacionRoutes,
                                 MenuRoutes menuRoutes,
                                 TipoMenuRoutes tipoMenuRoutes,
                                 MesaRoutes mesaRoutes,
                                 UsuarioRoutes usuarioRoutes)
        {
            _clienteRoutes = clienteRoutes;
            _reservacionRoutes = reservacionRoutes;
            _menuRoutes = menuRoutes;
            _tipoMenuRoutes = tipoMenuRoutes;
            _mesaRoutes = mesaRoutes;
            _usuarioRoutes = usuarioRoutes;
        }

        public ClienteRoutes Cliente => _clienteRoutes;
        public ReservacionRoutes Reservacion => _reservacionRoutes;
        public MenuRoutes Menu => _menuRoutes;
        public TipoMenuRoutes TipoMenu => _tipoMenuRoutes;
        public MesaRoutes Mesa => _mesaRoutes;
        public UsuarioRoutes Usuario => _usuarioRoutes;
    }
}
