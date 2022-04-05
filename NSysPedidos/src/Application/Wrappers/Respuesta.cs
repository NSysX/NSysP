namespace Application.Wrappers
{
    public class Respuesta<T>
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }


        public Respuesta()
        {

        }

        public Respuesta(T data, string? mensaje = null)
        {
            this.Succeeded = true;
            this.Message = mensaje;
            this.Data = data;
        }

        public Respuesta(string mensaje)
        {
            this.Succeeded = false;
            this.Message = mensaje;
        }

    }
}
