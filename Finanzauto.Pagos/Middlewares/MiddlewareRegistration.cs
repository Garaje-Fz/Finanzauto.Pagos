using Finanzauto.Utils.Exceptions.Middleware;

namespace Finanzauto.Pagos.Middlewares
{
    public static class MiddlewareRegistration
    {
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
