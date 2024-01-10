namespace Restaurante.LogicaNegocio.Services.Interfaces
{
    public interface IPasswordService
    {
        bool Check(string hashedPassword, string plainPassword);
        string Hash(string plainPassword);
    }
}
