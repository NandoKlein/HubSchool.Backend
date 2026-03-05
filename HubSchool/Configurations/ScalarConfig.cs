using Scalar.AspNetCore;

namespace HubSchool.Configurations
{
    public static class ScalarConfig
    {
        private static readonly string AppName = "HubSchool";
      
        public static WebApplication UseScalarConfiguration(this WebApplication app)
        {
            app.MapScalarApiReference("/scalar", options =>
            {
                options.WithTitle(AppName)
                       .WithOpenApiRoutePattern("/swagger/v1/swagger.json");

            });
            return app;
        }
    }
}
