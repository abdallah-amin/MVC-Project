namespace Demo.BLL.Services;
public interface IDepartmentServices
{
    DepartmentDetailsResponse? GetById(int id);
    IEnumerable<DepartmentResponse> GetAll();
    int Update(DepartmentUpdateRequest request);
    bool Delete(int id);
    int Add(DepartmentRequest request);

}
