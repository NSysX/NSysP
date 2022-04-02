using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ExcepcionDeValidacion : Exception
    {
        public ExcepcionDeValidacion() : base("Se han producido uno o mas errores de Validacion")
        {
            Errores = new List<string>();
        }

        public List<string> Errores { get; }

        public ExcepcionDeValidacion(IEnumerable<ValidationFailure> fallos) : this()
        {
            foreach (var fallo in fallos)
            {
                Errores.Add(fallo.ErrorMessage);
            }
        }
    }
}
