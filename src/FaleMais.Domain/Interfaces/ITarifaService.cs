using FaleMais.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FaleMais.Domain.Interfaces
{
    public interface ITarifaService
    {
        List<string> GetLocais();
        List<Plano> GetPlanos();
        double SimularPreco(string origem, string destino, int duracao);
        double SimularPrecoFaleMais(string origem, string destino, int duracao, Guid planoId);
    }
}
