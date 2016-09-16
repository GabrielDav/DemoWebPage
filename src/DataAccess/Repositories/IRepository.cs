namespace DataAccess.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
