namespace Courses.API.Data.Entities;

public class Course : BaseEntity
{
    public Guid CourseId { get; set; }

    public string? Name { get; set; }

    public int Duration { get; set; }

    public string? Description { get; set; }

    public string? PictureUrl { get; set; }
}
