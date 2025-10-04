namespace Demo.BLL.Services;
public interface IEmployeeServices
{
    // Get , GetAll , Update , Delete , Add

    EmployeeDetailsResponse? GetById(int id);
    IEnumerable<EmployeeResponse> GetAll();
    int Add(EmployeeRequest request);
    int Update(EmployeeUpdateRequest request);
    bool Delete(int id);

}
