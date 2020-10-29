using FaleMais.Domain.Entities;

namespace FaleMais.Tests.Builders.Entities
{
    public class TarifaBuilder
    {
        public Tarifa instance;

        public TarifaBuilder()
        {
            instance = new Tarifa("011", "016", 1.9);
        }

        public Tarifa Build()
        {
            return instance;
        }
    }
}
