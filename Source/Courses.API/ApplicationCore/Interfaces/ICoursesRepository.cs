using Courses.API.Data.Dtos;

namespace Courses.API.ApplicationCore.Interfaces;

public interface ICoursesRepository
{
    Task<IReadOnlyCollection<CourseDto>> GetAllCourses();
}