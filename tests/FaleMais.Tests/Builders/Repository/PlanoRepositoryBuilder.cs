using FaleMais.Domain.Entities;
using FaleMais.Domain.Interfaces;
using Moq;
using System.Collections.Generic;

namespace FaleMais.Tests.Builders.Repository
{
    public class PlanoRepositoryBuilder
    {
        private static PlanoRepositoryBuilder _instance;
        private readonly Mock<IPlanoRepository> _repository;

        public PlanoRepositoryBuilder()
        {
            if (_repository == null)
                _repository = new Mock<IPlanoRepository>();
        }

        public PlanoRepositoryBuilder Exists(Plano plano)
        {
            _repository.Setup(r => r.Get(plano.Id)).Returns(() => plano);
            _repository.Setup(r => r.Get()).Returns(() => new List<Plano> { plano });

            return this;
        }

        public static PlanoRepositoryBuilder Instance()
        {
            _instance = new PlanoRepositoryBuilder();
            return _instance;
        }

        public IPlanoRepository Build()
        {
            return _repository.Object;
        }
    }
}
