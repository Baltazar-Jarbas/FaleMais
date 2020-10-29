using System.Threading;

namespace FaleMais.Ui.Web.Extensions
{
    public static class CurrencyExtensions
    {
        public static string CurrencyFormat(this double valor)
        {
            return valor > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor) : "Gratuito";
        }

        public static string CurrencyFormat(this decimal valor)
        {
            return valor > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor) : "Gratuito";
        }

        public static string CurrencyFormat(this float valor)
        {
            return valor > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor) : "Gratuito";
        }
    }
}
