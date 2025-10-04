using System.ComponentModel.DataAnnotations;

namespace Demo.BLL.DataTransferObjects.Departments;
public class DepartmentRequest
{
    [Required(ErrorMessage = "Name is Required")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "You Must Add Code")]
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } // User Input

}
