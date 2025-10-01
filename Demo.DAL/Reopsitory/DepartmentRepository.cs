namespace Demo.DAL.Repository;
public class DepartmentRepository(CompanyDbContext dbContext) : IDepartmentRepository
{
    private readonly DbSet<Department> _departments = dbContext.Departments;
    public int Add(Department department)
    {
        _departments.Add(department);
        return dbContext.SaveChanges();
    }

    public int Delete(Department department)
    {
        _departments.Remove(department);
        return dbContext.SaveChanges();
    }

    public IEnumerable<Department> GetAll(bool trackChanges = false)
    {
        return trackChanges ?
        _departments
        .Where(d => d.IsDeleted == false).ToList() :
        _departments.AsNoTracking()
        .Where(d => d.IsDeleted == false).ToList();
    }

    public Department? GetById(int id)
    {
        return _departments.Find(id);
    }

    public int Update(Department department)
    {
        _departments.Update(department);
        return dbContext.SaveChanges();
    }
}
