using Microsoft.OpenApi;

namespace HubSchool.Configurations
{
    public static class OpenAPIConfig
    {
        private static readonly string AppName = "ASP.NET 2026 REST API´s from 0 to Azure and GCP com .NET 10, Docker e Kubernetes";
        private static readonly string AppDescription = $"API´s developed in course {AppName}";

        public static IServiceCollection AddOpenAPIConfig(this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
            {
                Title = AppName,
                Version = "v1",
                Description = AppDescription,
                Contact = new OpenApiContact
                {
                    Name = "Nando",
                    Url = new Uri("https://erudio.com.br")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/license/mit/")
                }
            });
            return services;
        }
    }
}
