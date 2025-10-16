using Demo.DAL.Repository;

namespace Demo.DAL.Reopsitory;
public interface IUnitOfWork
{
    IEmployeeRepository Employees { get; }
    IDepartmentRepository Departments { get; }
    Task<int> SaveChangesAsync();

}
