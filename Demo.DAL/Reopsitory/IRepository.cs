namespace Demo.DAL.Repository;
public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
    Task<TEntity?> GetByIdAsync(int Id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);

}
