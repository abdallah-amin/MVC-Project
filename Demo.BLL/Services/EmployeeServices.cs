namespace Demo.BLL.Services;
public class EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper,
    IDocumentService documentService) : IEmployeeServices
{
    public async Task<int> AddAsync(EmployeeRequest request)
    {
        var employee = mapper.Map<Employee>(request);
        if (request.Image is not null && request.Image.Length > 0)
        {
            var imageName = await documentService.UploadAsync(request.Image, "Images");
            employee.Image = imageName;
        }
        unitOfWork.Employees.Add(employee);
        return await unitOfWork.SaveChangesAsync();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await unitOfWork.Employees.GetByIdAsync(id);
        if (employee is null)
            return false;
        unitOfWork.Employees.Delete(employee);
        var result = await unitOfWork.SaveChangesAsync();
        if (result > 0)
        {
            if(employee.Image is not null)
                documentService.Delete(employee.Image, "Images");
            return true;
        }
        return false;
    }
    public async Task<IEnumerable<EmployeeResponse>> GetAllAsync()
    {
        var employees = await unitOfWork.Employees.GetAllAsync(
            e => new EmployeeResponse
            {
                Id = e.Id,
                Age = e.Age,
                Email = e.Email,
                EmployeeType = e.EmployeeType.ToString(),
                Gender = e.Gender.ToString(),
                IsActive = e.IsActive,
                Name = e.Name,
                Salary = e.Salary,
                Department = e.Department.Name
            });
        return employees;
    }
    public async Task<IEnumerable<EmployeeResponse>> GetAllAsync(string? searchValue)
    {
        var employees = await unitOfWork.Employees.GetAllAsync(
            e => new EmployeeResponse
            {
                Id = e.Id,
                Age = e.Age,
                Email = e.Email,
                EmployeeType = e.EmployeeType.ToString(),
                Gender = e.Gender.ToString(),
                IsActive = e.IsActive,
                Name = e.Name,
                Salary = e.Salary,
                Department = e.Department.Name
            },
            e => e.Name.Contains(searchValue));
        return employees;
    }
    public async Task<EmployeeDetailsResponse?> GetByIdAsync(int id)
    {
        var employee = await unitOfWork.Employees.GetByIdAsync(id);
        return mapper.Map<EmployeeDetailsResponse>(employee);
    }
    public async Task<int> UpdateAsync(EmployeeUpdateRequest request)
    {
        var emp = await unitOfWork.Employees.GetByIdAsync(request.Id);
        var image = emp.Image;
        emp = mapper.Map(request, emp); 
        if (request.Image is null)
            emp.Image = image;
        else if(request.Image.Length > 0)
        {
            var imageName = await documentService.UploadAsync(request.Image, "Images");
            emp.Image = imageName;
        }
        unitOfWork.Employees.Update(emp);
        var result = await unitOfWork.SaveChangesAsync();
        if (request.Image is not null && image is not null)
        {
            documentService.Delete(image, "Images");
        }
        return result;
    }
}
