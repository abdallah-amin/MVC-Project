namespace Demo.BLL.Services;
public interface IEmployeeServices
{
    // Get , GetAll , Update , Delete , Add

    Task<EmployeeDetailsResponse?> GetByIdAsync(int id);
    Task<IEnumerable<EmployeeResponse>> GetAllAsync();
    Task<IEnumerable<EmployeeResponse>> GetAllAsync(string searchValue);
    Task<int> AddAsync(EmployeeRequest request);
    Task<int> UpdateAsync(EmployeeUpdateRequest request);
    Task<bool> DeleteAsync(int id);

}
