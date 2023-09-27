using AutoMapper;
using AutoMapper.QueryableExtensions;
using EjemploRepartos_repository.Interface;
using EjemploRepartos_service.Dto.DtoMaster;
using EjemploRepartos_service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EjemploRepartos_service.Service
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository _masterRepository;
        private readonly IMapper _mapper;

        public MasterService(IMasterRepository masterRepository,
                             IMapper mapper)
        {
            _masterRepository = masterRepository;
            _mapper = mapper;
        }

       public async Task<List<MasterDto>> GetEstadoPedidoAsync() 
       {
            return await _masterRepository.GetMaeEstadoPedidos().ProjectTo<MasterDto>(_mapper.ConfigurationProvider).ToListAsync();
       }

        public async Task<List<MasterDto>> GetComidasAsync()
        {
            return await _masterRepository.GetMaeComidas().ProjectTo<MasterDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
