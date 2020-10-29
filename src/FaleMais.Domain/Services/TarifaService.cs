using FaleMais.Domain.Entities;
using FaleMais.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace FaleMais.Domain.Services
{

    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;
        private readonly IPlanoRepository _planoRepository;

        public TarifaService(ITarifaRepository tarifaRepository, IPlanoRepository planoRepository)
        {
            _tarifaRepository = tarifaRepository;
            _planoRepository = planoRepository;
        }

        public List<string> GetLocais()
            => _tarifaRepository.GetLocais();

        public List<Plano> GetPlanos()
            => _planoRepository.Get();

        public double SimularPreco(string origem, string destino, int duracao)
        {
            var tarifa = _tarifaRepository.Get(origem, destino);
            if (tarifa == null) return 0;

            return tarifa.Valor * duracao;
        }

        public double SimularPrecoFaleMais(string origem, string destino, int duracao, Guid planoId)
        {
            var tarifa = _tarifaRepository.Get(origem, destino);
            if (tarifa == null) return 0;

            var plano = _planoRepository.Get(planoId);

            return plano.Duracao switch
            {
                30 => new SimularPrecoFaleMaisTrinta().Simular(tarifa, duracao),
                60 => new SimularPrecoFaleMaisSessenta().Simular(tarifa, duracao),
                120 => new SimularPrecoFaleMaisCentoEVinte().Simular(tarifa, duracao),
                _ => 0,
            };
        }
    }
}
