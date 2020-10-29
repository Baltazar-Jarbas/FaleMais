using FaleMais.Domain.Entities;

namespace FaleMais.Domain.Services
{
    public class SimularPrecoFaleMaisTrinta : SimularPrecoFaleMais
    {
        public override double Simular(Tarifa tarifa, int duracao)
        {
            return duracao > 30 ? (tarifa.Valor * _acrescimo) * duracao : 0;
        }
    }
}
