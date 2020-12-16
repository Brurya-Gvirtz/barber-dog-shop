using NLog;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace BarberShopServer.Helpers
{
    public class ExceptionLogFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override bool AllowMultiple => true;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;

            var exceptionType = actionExecutedContext.Exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Access to the Web API is not authorized please login first.";
                status = HttpStatusCode.Unauthorized;
            }

            else
            {
                message = "Internal server error.";
                status = HttpStatusCode.InternalServerError;
            }

            try
            {
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),

                    StatusCode = status
                };
                logger.Error(actionExecutedContext.Exception);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            base.OnException(actionExecutedContext);
        }

    }
}