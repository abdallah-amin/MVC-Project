namespace Demo.BLL.Services;
public class EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeServices
{
    public int Add(EmployeeRequest request)
    {
        var employee = mapper.Map<Employee>(request);
        unitOfWork.Employees.Add(employee);
        return unitOfWork.SaveChanges();
    }

    public bool Delete(int id)
    {
        var employee = unitOfWork.Employees.GetById(id);
        if (employee is null)
            return false;
        unitOfWork.Employees.Delete(employee);
        return unitOfWork.SaveChanges() > 0;
    }

    public IEnumerable<EmployeeResponse> GetAll()
    {
        var employees = unitOfWork.Employees.GetAll(
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
    public IEnumerable<EmployeeResponse> GetAll(string? searchValue)
    {
        var employees = unitOfWork.Employees.GetAll(
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

    public EmployeeDetailsResponse? GetById(int id)
    {
        var employee = unitOfWork.Employees.GetById(id);
        return mapper.Map<EmployeeDetailsResponse>(employee);
    }

    public int Update(EmployeeUpdateRequest request)
    {
        unitOfWork.Employees.Update(mapper.Map<Employee>(request));
        return unitOfWork.SaveChanges();
    }
}
