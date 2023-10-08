namespace Schedule_API.Common.DTO;

public class GroupDto
{
    public GroupDto(Guid groupId, Guid facultyId, string name, bool isSubgroup)
    {
        GroupId = groupId;
        FacultyId = facultyId;
        Name = name;
        IsSubgroup = isSubgroup;
    }

    public Guid GroupId { get; set; }
    public Guid? FacultyId { get; set; }
    public string Name { get; set; }
    public bool IsSubgroup { get; set; }
}