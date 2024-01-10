namespace Restaurante.AccesoDatos.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IUsuarioRepository Usuario { get; }
        public IClienteRepository Cliente { get; }
        public IMenuRepository Menu { get; }
        public IMesaRepository Mesa { get; }
        public IReservacionRepository Reservacion { get; }
        public ITipoMenuRepository TipoMenu { get; }

        public bool Save();
    }
}
