namespace Demo.DAL.Repository;
public class DepartmentRepository(CompanyDbContext dbContext) : BaseRepository<Department, int>(dbContext), IDepartmentRepository
{

}
