# .NET 7 - Hands-on Minimal API with ASP.NET Core and Static data

## Date Time: 06-Mar-2023 at 08:30 PM IST

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

> 1. 30,000 foot view of REST, and HTTP
>    - HTTP Methods
>    - HTTP Responses
>    - What should I send as Response
>    - REST (Uniform, Stateless, Cacheable, Layered, Resources, and Self-Descriptive)
> 1. Introduction to .NET Minimal API
> 1. Creating Minimal API using dotnet CLI
>    - `dotnet new list`
>    - Create Minimal API using `dotnet new web`
>    - Create Minimal API using `dotnet new webapi -minimal`
> 1. Create Minimal API using `VS 2022` - Web API Templated - Uncheck Controllers
>    - Executing it using IIS Express / Kestrel Server
>    - Exploring Swagger
> 1. Create Minimal API using `VS 2022` - Web App Empty Template
>    - Executing it using IIS Express / Kestrel Server
> 1. Exposing 4 `Hello World` API Endpoints
> 1. Using Postman to test the API (Environment Variables, and Collections)
> 1. Layered Architecture
> 1. Creating Unified Response Dto, and Constants
> 1. Testing using
>    - Swagger | Postman | Browser Dev Tools

### Please refer to the [**Source Code**](https://github.com/Microservices-for-Small-Computer-School/Services-Courses) of today's session for more details

---

![Information | 100x100](./Images/SeatBelt.PNG)

---

## 1. 30,000 foot view of HTTP, and REST

> 1. Discussion and Demo

**References:**

> 1. [https://rapidapi.com/blog/rest-api-vs-web-api](https://rapidapi.com/blog/rest-api-vs-web-api)
> 1. [https://www.guru99.com/api-vs-web-service-difference.html#:~:text=Web%20service%20is%20used%20for,APIs%20are%20not%20web%20services.](https://www.guru99.com/api-vs-web-service-difference.html#:~:text=Web%20service%20is%20used%20for,APIs%20are%20not%20web%20services.)
> 1. [https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods)
> 1. [https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/200](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/200)
> 1. [https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods/PUT](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods/PUT)

### HTTP Methods

> 1. Discussion and Demo

### HTTP Responses

> 1. Discussion and Demo

### What should I send as Response

> 1. Discussion and Demo

### REST (Uniform, Stateless, Cacheable, Layered, Resources, and Self-Descriptive)

> 1. Discussion and Demo

**References:**

> 1. [https://en.wikipedia.org/wiki/Representational_state_transfer](https://en.wikipedia.org/wiki/Representational_state_transfer)

## 2. Introduction to .NET Minimal API

> 1. Discussion and Demo

**References:**

> 1. [https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-7.0](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-7.0)

## 3. Creating Minimal API using dotnet CLI

> 1. Discussion and Demo

```dotnetcli
dotnet new list
```

![Dotnet New List | 100x100](./Images/DotnetNewList.PNG)

### Create Minimal API using `dotnet new web`

> 1. Discussion and Demo
> 1. Executing it using dotnet CLI / VS Code

```dotnetcli
dotnet new web -o firstsample --dry-run
```

![Dotnet New Web | 100x100](./Images/DotNetNew_CLI_1.PNG)

### Create Minimal API using `dotnet new webapi -minimal`

> 1. Discussion and Demo
> 1. Executing it using dotnet CLI / VS Code

```dotnetcli
dotnet new webapi -minimal -o secondsample --dry-run
```

![Dotnet New WebApi | 100x100](./Images/DotNetNew_CLI_2.PNG)

## 4. Create Minimal API using `VS 2022` - Web API Template - Uncheck Controllers

> 1. Discussion and Demo

### Executing it using IIS Express / Kestrel Server

> 1. Discussion and Demo

### Exploring Swagger

> 1. Discussion and Demo.

![Web Api Template | 100x100](./Images/WebAPITemplate.PNG)

## 5. Create Minimal API using `VS 2022` - Web App Empty Template

> 1. Discussion and Demo

### Executing it using IIS Express, and Kestrel Server (http, https)

> 1. Discussion and Demo.

![Web App Empty Template | 100x100](./Images/WebAppEmptyTemplate.PNG)

## 6. Exposing `4 Basic` API Endpoints

> 1. Discussion and Demo

```csharp
app.MapGet(HelloWorldRoutes.Root, () => "Hello Minimal API World from Root !!");

app.MapGet(HelloWorldRoutes.HelloWorld, () =>
{
    return ApiResponseDto<string>.Create("Hello Minimal API World from /hw !!");
});

app.MapGet(HelloWorldRoutes.Api, DefaultResponseBusiness.SendDefaultApiEndpointOutput);

app.MapGet(HelloWorldRoutes.ApiV1, () => DefaultResponseBusiness.SendDefaultApiEndpointV1Output());
```

**References:**

> 1. [https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-7.0](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-7.0)

## 9. Creating Unified Response Dto, and Constants

> 1. Discussion and Demo

```csharp
public static class Constants
{
    public static class HelloWorldRoutes
    {
        public static string Root => "/";

        public static string HelloWorld => "/hw";

        public static string Api => "/api";

        public static string ApiV1 => "/api/v1";
    }
}

public record ApiResponseDto<T>
{
    public bool Success { get; set; }

    public string? Message { get; set; }

    public DateTimeOffset DateRequested => DateTimeOffset.UtcNow;

    public T? Data { get; set; }

    public static ApiResponseDto<T> Create(T? data = default, string message = "Success", bool success = true)
    {
        return new()
        {
            Success = success,
            Message = message,
            Data = data
        };
    }
}
```

## 7. Using Postman to test the API (Environment Variables, and Collections)

> 1. Discussion and Demo

![Postman Collections | 100x100](./Images/PostmanCollections.PNG)

## 8. Layered Architecture

> 1. Discussion and Demo

## 10. Testing using - Swagger, Postman, and Browser Dev Tools

> 1. Discussion and Demo

---

## SUMMARY / RECAP / Q&A

> 1. SUMMARY / RECAP / Q&A
> 2. Any open queries, I will get back through meetup chat/twitter.

---

## What is Next? session `2` of `5` Sessions on 07 Mar, 2023

> 1. Tour of .NET 7 Minimal API Project (Web API, and Web App Empty Template)
> 1. Dependency Injection, and Comparision of Service Collections
>    - Web App Empty
>    - Web API with Uncheck Controllers
>    - Web API with Controllers
> 1. Comparison of HTTP Request Pipeline
> 1. Parameter Binding
>    - From Query | From Route | From Body | From Services
> 1. Base Entity
> 1. Course Entity inheriting Base Entity
> 1. Just enough `Entity Framework` Core (In Memory)
> 1. Dependency Injection of DbContext
> 1. GetAllCourses() API Endpoint
> 1. Seed Data
> 1. Update Postman Collections to test the API (Environment Variables, and Collections)
