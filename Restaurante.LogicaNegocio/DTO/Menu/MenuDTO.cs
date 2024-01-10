namespace Restaurante.LogicaNegocio.DTO.Menu
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public string TcDscMenu { get; set; }
        public int TnIdTipoMenu { get; set; }
        public decimal TdPrecio { get; set; }
        
        //Tipo Menu
        public string TcDscTipoMenu { get; set; }
    }
}
