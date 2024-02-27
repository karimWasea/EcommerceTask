namespace IRepositories
{
    public interface IRepository<TEntity>    where TEntity : class
    {
       TEntity GetByIdAsync(int id);
        int AddAsync(TEntity entity);
        int UpdateAsync(TEntity entity);
        void DeleteAsync(int id);
    }

}
