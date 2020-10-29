using FaleMais.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FaleMais.Domain.Interfaces
{
    public interface IPlanoRepository
    {
        List<Plano> Get();
        Plano Get(Guid id);
        void Add(Plano plano);
        void Remove(Plano plano);

    }
}
