using Courses.API.ApplicationCore.Interfaces;
using Courses.API.Business;
using Courses.API.Configuration;
using Courses.API.Persistence;
using Courses.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Courses.API.Extensions;

public static class DependedServicesExtensions
{

    public static IServiceCollection ConfigureDependedServices(this IServiceCollection services)
    {
        _ = services.AddDbContext<SchoolDbContext>(options => options.UseInMemoryDatabase(InMemoryDatabase.Name));

        _ = services.AddAutoMapper(typeof(AutoMapperConfig));

        _ = services.AddScoped<ICoursesBusiness, CoursesBusiness>();

        _ = services.AddScoped<ICoursesRepository, CoursesRepository>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = services.AddEndpointsApiExplorer();
        _ = services.AddSwaggerGen();

        _ = services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader()
                                                            .WithOrigins("http://localhost:4007")
                                                            .AllowAnyMethod());
        });

        return services;
    }
}
