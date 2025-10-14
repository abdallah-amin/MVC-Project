using System.Linq.Expressions;

namespace Demo.DAL.Repository;
public class EmployeeRepository(CompanyDbContext dbContext) : BaseRepository<Employee, int>(dbContext), IEmployeeRepository
{
    public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector,
        Expression<Func<Employee, bool>>? predicate = null)
    {
        if (predicate is null)
            return _dbSet.Where(e => !e.IsDeleted).Select(resultSelector).ToList();

        return _dbSet.Where(e => !e.IsDeleted).Where(predicate).Select(resultSelector).ToList();
    }

    public override Employee? GetById(int id)
    {
        return _dbSet.Include(e => e.Department)
        .FirstOrDefault(e => e.Id == id);

    }
}
