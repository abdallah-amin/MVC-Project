using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.DAL.Repository;
public class EmployeeRepository(CompanyDbContext dbContext) : BaseRepository<Employee, int>(dbContext), IEmployeeRepository
{
    public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<Employee, TResult>> resultSelector,
        Expression<Func<Employee, bool>>? predicate = null)
    {
        if (predicate is null)
            return await _dbSet.Where(e => !e.IsDeleted).Select(resultSelector).ToListAsync();

        return await _dbSet.Where(e => !e.IsDeleted).Where(predicate).Select(resultSelector).ToListAsync();
    }

    public override async Task<Employee?> GetByIdAsync(int id)
    {
        return await _dbSet.Include(e => e.Department)
        .FirstOrDefaultAsync(e => e.Id == id);

    }
}
