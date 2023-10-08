namespace Schedule_API.Common.DTO;

public class GroupRequest
{
    public Guid FacultyId { get; set; }
    public string Name { get; set; }
    public bool IsSubgroup { get; set; }
}