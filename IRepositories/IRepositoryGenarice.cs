namespace IRepositories
{
    public interface IRepository<TEntity>    where TEntity : class
    {
       TEntity GetById (int id);
        int Add (TEntity entity);
        int Update (TEntity entity);
        void Delete(int id);
    }

}
