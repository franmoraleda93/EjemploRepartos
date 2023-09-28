using EjemploRepartos_helper.Exception.Type;
using EjemploRepartos_repository.Interface;
using EjemploRepartos_service.Service;
using FakeItEasy;
using Xunit;

namespace EjemploRepartos_Tests
{
    public class AuthorizeServiceTest
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepartidorRepository _repartidorRepository;
        private readonly IHeaderRepository _headerRepository;

        public AuthorizeServiceTest()
        {
            _clienteRepository = A.Fake<IClienteRepository>();
            _repartidorRepository = A.Fake<IRepartidorRepository>();
            _headerRepository = A.Fake<IHeaderRepository>();
        }

        [Fact]
        public async Task ValidateClienteAsync_When_OidCliente_IsNullOrEmpty()
        {
            //Arrange
            string oidCliente = "";

            A.CallTo(() => _headerRepository.GetOidCliente()).Returns(oidCliente);

            var authorizeService = new AuthorizeService(_clienteRepository, _repartidorRepository, _headerRepository);

            // Action Assert.
            await Assert.ThrowsAsync<ResourceForbiddenException>(() => authorizeService.ValidateClienteAsync());
        }
    }
}
