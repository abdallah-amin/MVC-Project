namespace Demo.BLL.Services;
public interface IDepartmentServices
{
    Task<DepartmentDetailsResponse?> GetByIdAsync(int id);
    Task<IEnumerable<DepartmentResponse>> GetAllAsync();
    Task<int> UpdateAsync(DepartmentUpdateRequest request);
    Task<bool> DeleteAsync(int id);
    Task<int> AddAsync(DepartmentRequest request);

}
