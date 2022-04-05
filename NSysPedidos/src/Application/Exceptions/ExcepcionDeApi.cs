using System.Globalization;

namespace Application.Exceptions
{
    public class ExcepcionDeApi : Exception
    {
        public ExcepcionDeApi() : base()
        {
        }

        public ExcepcionDeApi(string mensaje) : base(mensaje)
        {
        }

        public ExcepcionDeApi(string mensaje, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, mensaje, args))
        {
        }
    }
}
