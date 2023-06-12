using DcaModels;
using System.Linq.Expressions;

namespace DcaServices.DataAccess;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task<TEntity> Add(TEntity entity);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> Get(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task Remove(int id);
    Task Update(TEntity entity);
}
