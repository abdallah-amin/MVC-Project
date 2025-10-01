namespace Demo.BLL.Services;
public class DepartmentServices(IDepartmentRepository departmentRepository) : IDepartmentServices
{
    public int Add(DepartmentRequest request)
    {
        return departmentRepository.Add(request.ToEntity());
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
        return departmentRepository.GetAll().Select(x => x.ToResponse());
    }

    public DepartmentDetailsResponse? GetById(int id)
    {
        return departmentRepository.GetById(id)?.ToDetailsResponse();
    }

    public int Update(DepartmentUpdateRequest request)
    {
        return departmentRepository.Update(request.ToEntity());
    }
}
