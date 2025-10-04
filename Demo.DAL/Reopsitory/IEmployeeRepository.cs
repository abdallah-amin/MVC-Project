namespace Demo.DAL.Repository;
public interface IEmployeeRepository : IRepository<Employee, int>
{
    IEnumerable<Employee> GetAll(string name);
}
