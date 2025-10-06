using System.Linq.Expressions;

namespace Demo.DAL.Repository;
public interface IEmployeeRepository : IRepository<Employee, int>
{
    IEnumerable<Employee> GetAll(string name);
    IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector);

}
