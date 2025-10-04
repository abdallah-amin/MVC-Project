namespace Demo.BLL.DataTransferObjects.Departments;
public class DepartmentResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

}
