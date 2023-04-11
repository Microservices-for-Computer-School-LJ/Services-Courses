using AutoMapper;
using Courses.API.Data.Dtos;
using Courses.API.Data.Entities;

namespace Courses.API.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        _ = CreateMap<Course, CourseDto>().ReverseMap();

        _ = CreateMap<Course, CreateCourseDto>().ReverseMap();
    }
}