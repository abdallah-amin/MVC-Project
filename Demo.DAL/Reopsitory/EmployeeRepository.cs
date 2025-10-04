namespace Demo.DAL.Repository;
public class EmployeeRepository(CompanyDbContext dbContext) : BaseRepository<Employee, int>(dbContext), IEmployeeRepository
{
    public IEnumerable<Employee> GetAll(string name)
    {
        return _dbSet.Where(x => x.Name == name).ToList();
    }

}
