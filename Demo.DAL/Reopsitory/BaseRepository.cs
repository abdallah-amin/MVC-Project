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

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
    {
        return trackChanges ?
        await _dbSet
        .Where(d => d.IsDeleted == false).ToListAsync() :
        await _dbSet.AsNoTracking()
        .Where(d => d.IsDeleted == false).ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual void Update(TEntity TEntity)
    {
        _dbSet.Update(TEntity);
    }

}
