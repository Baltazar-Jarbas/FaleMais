using FaleMais.Domain.Services;
using FaleMais.Tests.Builders.Entities;
using FaleMais.Tests.Builders.Repository;
using Xunit;

namespace FaleMais.Tests
{
    public class TarifaServiceTests
    {
        [Fact()]
        public void SimularPreco__Should_Be_True()
        {
            //
            //Arrange
            int duracao = 10;
            var tarifa = new TarifaBuilder().Build();
            var plano = new PlanoBuilder().Build();

            var tarifaRepository = TarifaRepositoryBuilder.Instance().Exists(tarifa).Build();
            var planoRepository = PlanoRepositoryBuilder.Instance().Exists(plano).Build();
                
            
            var service = new TarifaService(tarifaRepository, planoRepository);

            //
            // Act
            var response = service.SimularPreco(tarifa.Origem, tarifa.Destino, duracao);

            //
            // Assert
            Assert.Equal(tarifa.Valor * duracao, response);
        }

        [Fact()]
        public void SimularPrecoFaleMais__Should_Be_True()
        {
            //
            //Arrange
            int duracao = 31;
            double acrescimoExcedente = 1.1;
            var tarifa = new TarifaBuilder().Build();
            var plano = new PlanoBuilder().Build();

            var tarifaRepository = TarifaRepositoryBuilder.Instance().Exists(tarifa).Build();
            var planoRepository = PlanoRepositoryBuilder.Instance().Exists(plano).Build();


            var service = new TarifaService(tarifaRepository, planoRepository);

            //
            // Act
            var response = service.SimularPrecoFaleMais(tarifa.Origem, tarifa.Destino, duracao, plano.Id);

            //
            // Assert
            Assert.Equal((tarifa.Valor * acrescimoExcedente) * duracao, response);
        }
    }
}
