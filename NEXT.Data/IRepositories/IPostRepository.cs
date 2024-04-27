namespace NEXT.Data.IRepositories;

public interface IPostRepository<TEntity>
{
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task<bool> DeleteAsync(long id);
    public Task<TEntity> GetByIdAsync(long id);
    public IQueryable<TEntity> GetAllAsync();
}
