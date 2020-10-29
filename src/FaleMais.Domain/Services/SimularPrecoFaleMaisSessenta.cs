using FaleMais.Domain.Entities;

namespace FaleMais.Domain.Services
{
    public class SimularPrecoFaleMaisSessenta : SimularPrecoFaleMais
    {
        public override double Simular(Tarifa tarifa, int duracao)
        {
            return duracao > 60 ? tarifa.Valor * _acrescimo * duracao : 0;
        }
    }
}
