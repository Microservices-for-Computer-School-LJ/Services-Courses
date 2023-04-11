using Courses.API.Endpoints;
using Courses.API.Persistence;

namespace Courses.API.Extensions;

public static class HttpRequestPipelineExtensions
{

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("AllowAll");

            // TODO: To be removed once we have .sqlproj
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetService<SchoolDbContext>();
            _ = (context?.Database.EnsureCreated());
        }

        // Endpoints
        app.MapHelloWorldEndpoints();
        app.MapUserEndpoints();
        app.MapCourseEndpoints();

        return app;
    }

}
