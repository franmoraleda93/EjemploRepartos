using EjemploRepartos_service.Dto.DtoMaster;

namespace EjemploRepartos_service.Interface
{
    public interface IMasterService
    {
        Task<List<MasterDto>> GetEstadoPedidoAsync();
        Task<List<MasterDto>> GetComidasAsync();
    }
}
