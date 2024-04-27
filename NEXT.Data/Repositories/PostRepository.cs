using Microsoft.EntityFrameworkCore;
using NEXT.Data.DbContexts;
using NEXT.Data.IRepositories;
using NEXT.Domain.Commons;

namespace NEXT.Data.Repositories
{
    public class PostRepository<TEntity> : IPostRepository<TEntity> where TEntity : Auditable
    {
        private readonly AppDbContext _db;
        private readonly DbSet<TEntity> Posts;

        public PostRepository(AppDbContext db)
        {
            _db = db;
            Posts = _db.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var post = await Posts.AddAsync(entity);
            await _db.SaveChangesAsync();
            return post.Entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var post = await Posts.FirstOrDefaultAsync(p => p.Id == id);
            _db.Remove(post);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            return Posts;
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            var post = await Posts.FirstOrDefaultAsync(p => p.Id == id);
            return post;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var post = Posts.Update(entity);
            var existingPost = await Posts.FindAsync(entity.Id);
            if (existingPost is null)
                return null;
            _db.Entry(existingPost).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
            return existingPost;

            return post.Entity;
        }
    }
}
