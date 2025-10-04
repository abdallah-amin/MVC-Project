namespace Demo.BLL.DataTransferObjects.Departments;
public static class DepartmentFactory
{
    public static DepartmentResponse ToResponse(this Department department)
    {
        return new()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt,
            Code = department.Code,
        };
    }
    public static DepartmentDetailsResponse ToDetailsResponse(this Department department)
    {
        return new()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            CreatedBy = department.CreatedBy,
            CreatedAt = department.CreatedAt,
            CreatedOn = department.CreatedOn,
            IsDeleted = department.IsDeleted,
            Code = department.Code,
            LastModifiedBy = department.LastModifiedBy,
            LastModifiedOn = department.LastModifiedOn
        };
    }
    public static Department ToEntity(this DepartmentRequest department)
    {
        return new()
        {
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt,
            Code = department.Code,
        };
    }
    public static Department ToEntity(this DepartmentUpdateRequest department)
    {
        return new()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt,
            Code = department.Code,
        };
    }
    public static DepartmentUpdateRequest ToUpdateRequest(this DepartmentDetailsResponse department)
    {
        return new()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt,
            Code = department.Code,
        };
    }
    public static DepartmentRequest ToRequest(this DepartmentUpdateRequest department)
    {
        return new()
        {
            Name = department.Name,
            Description = department.Description,
            Code = department.Code,
        };
    }


}