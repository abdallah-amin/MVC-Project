namespace Demo.DAL.Repository;
public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    IEnumerable<TEntity> GetAll(bool trackChanges = false);
    TEntity? GetById(int Id);
    int Add(TEntity entity);
    int Update(TEntity entity);
    int Delete(TEntity entity);

}
