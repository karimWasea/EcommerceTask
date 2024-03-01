namespace IRepositories
{
    public interface IUnitOfWork : IDisposable

    {
        Icategory  Icategory { get; }
        Isubcategory   Isubcategory { get; }
        IProduct    Product { get; }
        public IPackage Package { get; }


    }
}