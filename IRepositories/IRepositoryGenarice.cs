namespace IRepositories
{
    public interface IRepository<TEntity>    where TEntity : class
    {
       TEntity GetById (Guid id);
        int? Add (TEntity entity);
        int ?Update (TEntity entity);
        bool Delete(Guid id);
    }

}
