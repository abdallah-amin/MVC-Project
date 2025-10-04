namespace Demo.DAL.Repository;
public class BaseRepository<TEntity, TKey>(CompanyDbContext dbContext) : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    public virtual int Add(TEntity TEntity)
    {
        _dbSet.Add(TEntity);
        return dbContext.SaveChanges();
    }

    public virtual int Delete(TEntity TEntity)
    {
        _dbSet.Remove(TEntity);
        return dbContext.SaveChanges();
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

    public virtual int Update(TEntity TEntity)
    {
        _dbSet.Update(TEntity);
        return dbContext.SaveChanges();
    }

}
