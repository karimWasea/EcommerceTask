namespace IRepositories
{
    public interface IUnitOfWork : IDisposable

    {
        Icategory  Icategory { get; }

    }
}