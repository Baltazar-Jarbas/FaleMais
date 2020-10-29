namespace FaleMais.Domain.Entities
{
    public class Tarifa : Entity
    {
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public double Valor { get; private set; }

        public Tarifa(string origem, string destino, double valor)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }
    }
}
