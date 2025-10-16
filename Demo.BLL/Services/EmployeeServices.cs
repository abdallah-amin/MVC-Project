using System.Threading.Tasks;

namespace Demo.BLL.Services;
public class EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeServices
{
    public async Task<int> AddAsync(EmployeeRequest request)
    {
        var employee = mapper.Map<Employee>(request);
        unitOfWork.Employees.Add(employee);
        return await unitOfWork.SaveChangesAsync();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await unitOfWork.Employees.GetByIdAsync(id);
        if (employee is null)
            return false;
        unitOfWork.Employees.Delete(employee);
        return await unitOfWork.SaveChangesAsync() > 0;
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
        unitOfWork.Employees.Update(mapper.Map<Employee>(request));
        return await unitOfWork.SaveChangesAsync();
    }
}
