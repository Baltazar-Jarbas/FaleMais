using FaleMais.Domain.Entities;

namespace FaleMais.Domain.Services
{
    public class SimularPrecoFaleMaisCentoEVinte : SimularPrecoFaleMais
    {
        public override double Simular(Tarifa tarifa, int duracao)
        {
            return duracao > 120 ? tarifa.Valor * _acrescimo * duracao : 0;
        }
    }
}
