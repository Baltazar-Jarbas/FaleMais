using FaleMais.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FaleMais.Domain.Interfaces
{
    public interface ITarifaRepository
    {
        List<Tarifa> Get();
        Tarifa Get(Guid id);
        Tarifa Get(string origem, string destino);
        List<string> GetLocais();
        void Add(Tarifa tarifa);
        void Remove(Tarifa tarifa);
    }
}
