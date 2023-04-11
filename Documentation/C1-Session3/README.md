# .NET 7 Minimal API DI, IOC, record, DTOs, AutoMapper, and Extension Methods

## Date Time: 09-Mar-2023 at 08:30 PM IST

---

### Software/Tools

> 1. OS: Windows 10 x64
> 1. .NET 7
> 1. Visual Studio 2022
> 1. Visual Studio Code
> 1. Postman

### Prior Knowledge

> 1. Programming knowledge in C#

## Technology Stack

> 1. .NET 7, Azure

## Information

![Information | 100x100](./Images/Information.PNG)

## What are we doing today?

> 1. Create responses in Minimal API
> 1. Dependency Injection and Inversion of Control - Deep Dive
> 1. Enhancing GetAllCourses() API Endpoint to return Unified Response
> 1. Move the Hello World Endpoints into an Extension Class
> 1. Move the User Endpoints into an Extension Class
> 1. Move the Course Endpoints into an Extension Class
> 1. Creating Course Dtos using record
> 1. Auto Mapper Configuration
> 1. Dependency Injection of Auto Mapper
> 1. Enhancing GetAllCourses() API Endpoint to return Course Dtos
> 1. Update Postman Collections to test the API (Environment Variables, and Collections)

### Please refer to the [**Source Code**](https://github.com/Microservices-for-Small-Computer-School/Services-Courses) of today's session for more details

---

![Information | 100x100](./Images/SeatBelt.PNG)

---

## 1. Create responses in Minimal API

> 1. Discussion and Demo

**References:**

> 1. [https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/responses?view=aspnetcore-7.0](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/responses?view=aspnetcore-7.0)

## 2. Dependency Injection and Inversion of Control - Deep Dive

> 1. Discussion and Demo

**References:**

> 1. [https://en.wikipedia.org/wiki/Dependency_injection](https://en.wikipedia.org/wiki/Dependency_injection)
> 1. [https://en.wikipedia.org/wiki/Inversion_of_control](https://en.wikipedia.org/wiki/Inversion_of_control)
> 1. [https://dotnettutorials.net/lesson/introduction-to-inversion-of-control](https://dotnettutorials.net/lesson/introduction-to-inversion-of-control)
> 1. [https://alexalvess.medium.com/dependency-injection-and-inversion-of-control-on-net-core-3136fe98b72](https://alexalvess.medium.com/dependency-injection-and-inversion-of-control-on-net-core-3136fe98b72)

```csharp
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        _ = services.AddTransient<IFooter, Footer>();
        _ = services.AddTransient<IHeader, Header>();

        _ = services.AddTransient<IGenerateNames, GenerateNames>();

        _ = services.AddTransient<INamesArray, NamesArray>();
        _ = services.AddTransient<IPrintHelper, PrintHelper>();

        // IMPORTANT! Register the application entry point
        _ = services.AddTransient<NamesArrayApp>();

        return services;
    }
}
```

## 4. Enhancing GetAllCourses() API Endpoint to return Unified Response

> 1. Discussion and Demo

```csharp
app.MapGet(CoursesRoutes.Root, async ([FromServices] SchoolDbContext schoolDbContext) =>
{
    var coursesResponse = ApiResponseDto<IReadOnlyCollection<Course>>.Create(await schoolDbContext.Courses.ToListAsync());
    
    return Results.Ok(coursesResponse);
});
```

![Returning Course Entities | 100x100](./Images/ReturningCourseEntities.PNG)

## 5. Move the Hello World Endpoints into an Extension Class

> 1. Discussion and Demo

**Reference(s):**

> 1. [https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-7.0](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-7.0)

## 6. Move the User Endpoints into an Extension Class

> 1. Discussion and Demo

## 7. Move the Course Endpoints into an Extension Class

> 1. Discussion and Demo

## 8. Creating Course Dtos using record

> 1. Discussion and Demo

```csharp
public record CreateCourseDto
{
    public Guid CourseId { get; set; }

    public string? Name { get; set; }

    public int Duration { get; set; }

    public string? Description { get; set; }
}

public record CourseDto(Guid Id) : CreateCourseDto;
```

## 9. Auto Mapper Configuration

> 1. Discussion and Demo

```csharp
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        _ = CreateMap<Course, CourseDto>().ReverseMap();
        _ = CreateMap<Course, CreateCourseDto>().ReverseMap();
    }
}
```

## 10. Dependency Injection of Auto Mapper

> 1. Discussion and Demo

```csharp
_ = builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
```

## 9. Enhancing GetAllCourses() API Endpoint to return Dtos

> 1. Discussion and Demo

```csharp
_ = group.MapGet(CoursesRoutes.Root, async ([FromServices] SchoolDbContext schoolDbContext, IMapper mapper) =>
{
    var coursesResponse = ApiResponseDto<IReadOnlyCollection<CourseDto>>.Create(
            mapper.Map<IReadOnlyCollection<CourseDto>>(await schoolDbContext.Courses.ToListAsync())
        );
    return Results.Ok(coursesResponse);
});
```

![Returning Course Dtos | 100x100](./Images/ReturningCourseDtos.PNG)

## 10. Update Postman Collections to test the API (Environment Variables, and Collections)

> 1. Discussion and Demo

![Postman Collections | 100x100](./Images/PostmanCollections.PNG)

---

## SUMMARY / RECAP / Q&A

> 1. SUMMARY / RECAP / Q&A
> 2. Any open queries, I will get back through meetup chat/twitter.

---

## What is Next? session `4` of `5` Sessions on 10 Mar, 2023

> 1. Adding Swagger Dependencies
> 1. WithTags().WithName().Produces(200).ProducesProblem(500);
> 1. Creating Repository Layer
> 1. Creating Business Layer
> 1. Dependency Injection of Swagger, Repository Layer, Business Layer
> 1. Move Service Dependencies into a Extension Class
> 1. Move Http Request Pipeline Dependencies into a Extension Class
> 1. Update Postman Collections to test the API (Environment Variables, and Collections)
> 1. GitHub Actions to build API
