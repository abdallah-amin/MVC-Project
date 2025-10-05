namespace Demo.BLL.Services;
public class DepartmentServices(IDepartmentRepository departmentRepository, IMapper mapper) : IDepartmentServices
{
    public int Add(DepartmentRequest request)
    {
        var department = mapper.Map<Department>(request);
        return departmentRepository.Add(department);
    }

    public bool Delete(int id)
    {
        var department = departmentRepository.GetById(id);
        if (department is null)
            return false;
        var result = departmentRepository.Delete(department);
        return result > 0;
    }

    public IEnumerable<DepartmentResponse> GetAll()
    {
        var departments = departmentRepository.GetAll();
        return mapper.Map<IEnumerable<DepartmentResponse>>(departments);
    }

    public DepartmentDetailsResponse? GetById(int id)
    {
        var department = departmentRepository.GetById(id);
        return mapper.Map<DepartmentDetailsResponse>(department);
    }

    public int Update(DepartmentUpdateRequest request)
    {
        return departmentRepository.Update(mapper.Map<Department>(request));
    }
}
