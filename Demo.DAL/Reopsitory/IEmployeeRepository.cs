using System.Linq.Expressions;

namespace Demo.DAL.Repository;
public interface IEmployeeRepository : IRepository<Employee, int>
{
    IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector,
        Expression<Func<Employee, bool>>? predicate = null);

}
