using FaleMais.Domain.Entities;
using System;

namespace FaleMais.Tests.Builders.Entities
{
    public class PlanoBuilder
    {
        public Plano instance;

        public PlanoBuilder()
        {
            instance = new Plano(Guid.NewGuid(), "Plano Teste", 30);
        }

        public Plano Build()
        {
            return instance;
        }
    }
}
