using FaleMais.Domain.Entities;

namespace FaleMais.Domain.Services
{
    public abstract class SimularPrecoFaleMais
    {
        public readonly double _acrescimo = 1.1;
        public abstract double Simular(Tarifa tarifa, int duracao);
    }
}
