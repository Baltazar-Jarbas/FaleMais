using FaleMais.Domain.Entities;
using FaleMais.Domain.Interfaces;
using Moq;
using System.Collections.Generic;

namespace FaleMais.Tests.Builders.Repository
{
    public class TarifaRepositoryBuilder
    {
        private static TarifaRepositoryBuilder _instance;
        private readonly Mock<ITarifaRepository> _repository;

        public TarifaRepositoryBuilder()
        {
            if (_repository == null)
                _repository = new Mock<ITarifaRepository>();
        }

        public TarifaRepositoryBuilder Exists(Tarifa tarifa)
        {
            _repository.Setup(r => r.Get(tarifa.Id)).Returns(() => tarifa);
            _repository.Setup(r => r.Get()).Returns(() => new List<Tarifa> { tarifa});
            _repository.Setup(r => r.Get(tarifa.Origem, tarifa.Destino)).Returns(() => tarifa );
            _repository.Setup(r => r.GetLocais()).Returns(() => new List<string> { tarifa.Origem, tarifa.Destino });

            return this;
        }

        public static TarifaRepositoryBuilder Instance()
        {
            _instance = new TarifaRepositoryBuilder();
            return _instance;
        }

        public ITarifaRepository Build()
        {
            return _repository.Object;
        }

    }
}
