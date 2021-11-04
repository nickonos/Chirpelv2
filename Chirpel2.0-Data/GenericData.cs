using Chirpel2._0_Common.Interfaces.Context;
using Chirpel2._0_Common.Interfaces.Data;
using System.Linq.Expressions;

namespace Chirpel2._0_Data
{
    public class GenericData<TEntity> : IGenericData<TEntity> where TEntity : class
    {
        protected readonly IChirpelContext _dbContext;

        public GenericData(IChirpelContext context)
        {
            _dbContext = context;
        }

        public TEntity Get(string id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }
    }
}
