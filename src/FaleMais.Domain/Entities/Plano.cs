using System;

namespace FaleMais.Domain.Entities
{
    public class Plano : Entity
    {
        public string Nome { get; private set; }
        public int Duracao { get; private set; }

        public Plano(Guid id, string nome, int duracao)
        {
            Id = id;
            Nome = nome;
            Duracao = duracao;
        }
    }
}
