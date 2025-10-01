namespace Demo.DAL.Repository;
public interface IDepartmentRepository
{
    IEnumerable<Department> GetAll(bool trackChanges = false);
    Department? GetById(int Id);
    int Add(Department department);
    int Update(Department department);
    int Delete(Department department);
}
