namespace Demo.BLL.Services;
public class DepartmentServices(IUnitOfWork unitOfWork, IMapper mapper) : IDepartmentServices
{
    public int Add(DepartmentRequest request)
    {
        var department = mapper.Map<Department>(request);
        unitOfWork.Departments.Add(department);
        return unitOfWork.SaveChanges();
    }

    public bool Delete(int id)
    {
        var department = unitOfWork.Departments.GetById(id);
        if (department is null)
            return false;
        unitOfWork.Departments.Delete(department);
        return unitOfWork.SaveChanges() > 0;
    }

    public IEnumerable<DepartmentResponse> GetAll()
    {
        var departments = unitOfWork.Departments.GetAll();
        return mapper.Map<IEnumerable<DepartmentResponse>>(departments);
    }

    public DepartmentDetailsResponse? GetById(int id)
    {
        var department = unitOfWork.Departments.GetById(id);
        return mapper.Map<DepartmentDetailsResponse>(department);
    }

    public int Update(DepartmentUpdateRequest request)
    {
        
        unitOfWork.Departments.Update(mapper.Map<Department>(request));
        return unitOfWork.SaveChanges();
    }
}
