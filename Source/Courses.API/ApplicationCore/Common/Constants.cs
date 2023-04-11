namespace Courses.API.ApplicationCore.Common;

public static class Constants
{
    public static class HelloWorldRoutes
    {
        public static string Root => "/";

        public static string HelloWorld => "/hw";

        public static string Api => "/api";

        public static string ApiV1 => "/api/v1";
    }

    public static class UsersRoutes
    {
        public static string Prefix => "/api/users";

        public static string Root => "/";

        public static string ActionById => "/{id}";
    }

    public static class CoursesRoutes
    {
        public static string Prefix { get; } = "/api/courses";

        public static string Root => "/";
    }

    public static class InMemoryDatabase
    {
        public static string Name { get; } = "SchoolDatabase";
    }
}