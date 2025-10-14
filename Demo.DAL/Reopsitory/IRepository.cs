namespace Demo.DAL.Repository;
public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    IEnumerable<TEntity> GetAll(bool trackChanges = false);
    TEntity? GetById(int Id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);

}
