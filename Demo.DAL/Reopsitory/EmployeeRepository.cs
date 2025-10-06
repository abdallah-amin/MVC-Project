using System.Linq.Expressions;

namespace Demo.DAL.Repository;
public class EmployeeRepository(CompanyDbContext dbContext) : BaseRepository<Employee, int>(dbContext), IEmployeeRepository
{
    public IEnumerable<Employee> GetAll(string name)
    {
        return _dbSet.Where(x => x.Name == name).ToList();
    }
    public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector)
    {
        return _dbSet.Where(e => !e.IsDeleted).Select(resultSelector).ToList();
    }

}
