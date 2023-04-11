using Courses.API.Data.Dtos;

namespace Courses.API.ApplicationCore.Interfaces;

public interface ICoursesBusiness
{
    Task<ApiResponseDto<IReadOnlyCollection<CourseDto>>> GetAllCourses();
}

