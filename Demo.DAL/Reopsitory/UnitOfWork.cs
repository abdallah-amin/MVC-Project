using Demo.DAL.Repository;
using System.Threading.Tasks;

namespace Demo.DAL.Reopsitory;
public class UnitOfWork(CompanyDbContext dbContext,
    IEmployeeRepository employee,
    IDepartmentRepository department)
    : IUnitOfWork
{
    public IEmployeeRepository Employees => employee;

    public IDepartmentRepository Departments => department;

    public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
}
