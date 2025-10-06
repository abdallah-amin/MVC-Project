namespace Demo.BLL.Services;
public class EmployeeServices(IEmployeeRepository employeeRepository, IMapper mapper) : IEmployeeServices
{
    public int Add(EmployeeRequest request)
    {
        var employee = mapper.Map<Employee>(request);
        return employeeRepository.Add(employee);
    }

    public bool Delete(int id)
    {
        var employee = employeeRepository.GetById(id);
        if (employee is null)
            return false;
        var result = employeeRepository.Delete(employee);
        return result > 0;
    }

    public IEnumerable<EmployeeResponse> GetAll()
    {
        var employees = employeeRepository.GetAll(
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
            });
        return employees;
    }

    public EmployeeDetailsResponse? GetById(int id)
    {
        var employee = employeeRepository.GetById(id);
        return mapper.Map<EmployeeDetailsResponse>(employee);
    }

    public int Update(EmployeeUpdateRequest request)
    {
        return employeeRepository.Update(mapper.Map<Employee>(request));
    }
}
