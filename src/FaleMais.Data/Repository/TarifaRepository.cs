using FaleMais.Domain.Entities;
using FaleMais.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaleMais.Data.Repository
{
    public class TarifaRepository : ITarifaRepository
    {
        public List<Tarifa> Get()
            => _dbContext.ToList();

        public Tarifa Get(Guid id)
            => _dbContext.FirstOrDefault(x => x.Id == id);

        public Tarifa Get(string origem, string destino)
            => _dbContext.FirstOrDefault(x => x.Origem.Equals(origem) && x.Destino.Equals(destino));

        public List<string> GetLocais()
            => _dbContext.Select(x => x.Origem).Distinct().ToList();

        public void Add(Tarifa tarifa)
        {
            _dbContext.Add(tarifa);
        }

        public void Remove(Tarifa tarifa)
        {
            _dbContext.Remove(tarifa);
        }

        private readonly List<Tarifa> _dbContext = new List<Tarifa>
            {
                new Tarifa("011", "016", 1.90),
                new Tarifa("016", "011", 2.90),
                new Tarifa("011", "017",  1.70),
                new Tarifa("017", "011", 2.70),
                new Tarifa("011", "018", 0.90),
                new Tarifa("018", "011", 1.90)
            };
    }

    public class PlanoRepository : IPlanoRepository
    {
        public List<Plano> Get()
            => _dbContext.ToList();

        public Plano Get(Guid id)
            => _dbContext.FirstOrDefault(x => x.Id == id);

        public void Add(Plano plano)
        {
            _dbContext.Add(plano);
        }

        public void Remove(Plano plano)
        {
            _dbContext.Remove(plano);
        }

        private readonly List<Plano> _dbContext = new List<Plano>
            {
                new Plano(Guid.Parse("3ec986b3-40d8-45e8-8290-f66eecbedcf9"), "FaleMais 30",  30),
                new Plano(Guid.Parse("36704196-adde-4782-a866-72bd0c4f4e8f"), "FaleMais 60", 60),
                new Plano(Guid.Parse("3f7463a4-b57a-43f7-84d6-9f3bf91c9ea8"),"FaleMais 120", 120)
            };
    }
}
