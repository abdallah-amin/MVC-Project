using Demo.DAL.Repository;

namespace Demo.DAL.Reopsitory;
public class UnitOfWork(CompanyDbContext dbContext,
    IEmployeeRepository employee,
    IDepartmentRepository department)
    : IUnitOfWork
{
    public IEmployeeRepository Employees => employee;

    public IDepartmentRepository Departments => department;

    public int SaveChanges() => dbContext.SaveChanges();
}
