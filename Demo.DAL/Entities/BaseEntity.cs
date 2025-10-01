namespace Demo.DAL.Entities;
public class BaseEntity<TEntity>
{
    public TEntity Id { get; set; }
    public bool IsDeleted { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
}
