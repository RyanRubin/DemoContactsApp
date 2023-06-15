using DcaModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DcaServices.DataAccess;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DcaDbContext dbContext;

    public Repository(DcaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        dbContext.Set<TEntity>().Add(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await dbContext.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> Get(int id)
    {
        var existing = await dbContext.Set<TEntity>().FindAsync(id);
        if (existing is null)
        {
            return null;
        }
        dbContext.Entry(existing).State = EntityState.Detached;
        return existing;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task Remove(int id)
    {
        var existing = await dbContext.Set<TEntity>().FindAsync(id);
        if (existing is null)
        {
            return;
        }
        dbContext.Remove(existing);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        var existing = await dbContext.Set<TEntity>().FindAsync(entity.Id);
        if (existing is null)
        {
            return;
        }
        dbContext.Entry(existing).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;
    }
}
