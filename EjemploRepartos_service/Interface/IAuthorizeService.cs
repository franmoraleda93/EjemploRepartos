namespace EjemploRepartos_service.Interface
{
    public interface IAuthorizeService
    {
        Task ValidateClienteAsync();
        Task ValidateRepartidorAsync();
    }
}
