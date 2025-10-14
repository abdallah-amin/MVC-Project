namespace Demo.DAL.Repository;
public class BaseRepository<TEntity, TKey>(CompanyDbContext dbContext) : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    public virtual void Add(TEntity TEntity)
    {
        _dbSet.Add(TEntity);
    }

    public virtual void Delete(TEntity TEntity)
    {
        _dbSet.Remove(TEntity);
    }

    public virtual IEnumerable<TEntity> GetAll(bool trackChanges = false)
    {
        return trackChanges ?
        _dbSet
        .Where(d => d.IsDeleted == false).ToList() :
        _dbSet.AsNoTracking()
        .Where(d => d.IsDeleted == false).ToList();
    }

    public virtual TEntity? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Update(TEntity TEntity)
    {
        _dbSet.Update(TEntity);
    }

}
