using EjemploRepartos_helper.Exception;
using System.Net;
using System.Text.Json;

namespace EjemploRepartos_infrastructure.Exception
{
    public static class ExceptionExtension
    {
        public static (int Status, string Message) CreateResponseMessage(this System.Exception exception)
        {
            var message = "Error interno del servidor. Mas info: " + (exception.InnerException != null ? exception.InnerException.Message : exception.Message);
            HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

            if (exception is BaseException)
            {
                var baseException = exception as BaseException;

                message = baseException.Message;
                StatusCode = baseException.StatusCode;
            }

            ErrorProblemDetails error = new ErrorProblemDetails()
            {
                Status = (int)StatusCode,
                Title = message,
                Error = new ErrorProblemDetails.ClassError { resultError = new string[] { exception.Message } },
                TraceId = Guid.NewGuid().ToString()
            };

            string serializedResponse = JsonSerializer.Serialize(error);

            return ((int)StatusCode, serializedResponse);
        }
    }

    public class ErrorProblemDetails
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public ClassError Error { get; set; }

        public class ClassError
        {
            public string[] resultError { get; set; }
        }
    }
}
