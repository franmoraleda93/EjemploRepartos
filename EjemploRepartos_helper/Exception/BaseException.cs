using System.Net;

namespace EjemploRepartos_helper.Exception
{
    public class BaseException : System.Exception
    {
        public HttpStatusCode StatusCode { get; set; }


        private BaseException() : base()
        {
        }

        protected BaseException(string mensaje) : base(mensaje)
        {
        }
    }
}
