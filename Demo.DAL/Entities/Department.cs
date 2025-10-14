namespace Demo.DAL.Entities;
public class Department : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Employee> Employees { get; set; } = [];

}
