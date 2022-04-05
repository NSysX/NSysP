using Application.Interface;

namespace Shared.Services
{
    public class FechaHoraServicio : IFechaHoraServicio
    {
        public DateTime Ahora => DateTime.Now;
    }
}
