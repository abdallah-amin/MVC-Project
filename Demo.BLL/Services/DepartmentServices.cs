using System.Threading.Tasks;

namespace Demo.BLL.Services;
public class DepartmentServices(IUnitOfWork unitOfWork, IMapper mapper) : IDepartmentServices
{
    public async Task<int> AddAsync(DepartmentRequest request)
    {
        var department = mapper.Map<Department>(request);
        unitOfWork.Departments.Add(department);
        return await unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await unitOfWork.Departments.GetByIdAsync(id);
        if (department is null)
            return false;
        unitOfWork.Departments.Delete(department);
        return await unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<DepartmentResponse>> GetAllAsync()
    {
        var departments = await unitOfWork.Departments.GetAllAsync();
        return mapper.Map<IEnumerable<DepartmentResponse>>(departments);
    }

    public async Task<DepartmentDetailsResponse?> GetByIdAsync(int id)
    {
        var department = await unitOfWork.Departments.GetByIdAsync(id);
        return mapper.Map<DepartmentDetailsResponse>(department);
    }

    public async Task<int> UpdateAsync(DepartmentUpdateRequest request)
    {
        
        unitOfWork.Departments.Update(mapper.Map<Department>(request));
        return await unitOfWork.SaveChangesAsync();
    }
}
