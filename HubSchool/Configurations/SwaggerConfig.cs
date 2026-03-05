using Microsoft.OpenApi;

namespace HubSchool.Configurations
{   
        public static class SwaggerConfig
        {
            private static readonly string AppName = "HubSchool";
            private static readonly string AppDescription = $"{AppName} API´s developed for english schools ";

            public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
            {
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
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
                    options.CustomSchemaIds(Type => Type.FullName);
                });
                return services;
            }

            public static IApplicationBuilder UseSwaggerSpecification(this IApplicationBuilder app)
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = "swagger-ui";
                    options.DocumentTitle = AppName;
                });
                return app;
            }
        }
    }
