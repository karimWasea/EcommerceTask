using DataAccessLayer;
using DataAccessLayer.Migrations;

using IRepositories;


namespace RepositoryServices
{
    public class UnitOfWork :  IUnitOfWork
    {

        public readonly ApplicationDbContext _context;

        public UnitOfWork(BundelsServess bundelsServess , CategoryServess categoryServess , ApplicationDbContext _context , SubCategoryServess subCategoryServess , ProductyServess productServess , Packageervess Packageervess)

        {

            Product = productServess;
            Icategory = categoryServess;
              this. _context= _context;  
              Isubcategory= subCategoryServess;
            Package = Packageervess;
               Bundels = bundelsServess;
                 


        }

        #region Implement the Dispose method to release resources
        private bool disposed = false;

        public Icategory Icategory { get; }
        public Isubcategory Isubcategory { get; }
        public IProduct Product { get; }
        public IPackage Package { get; }
        public IBundels Bundels { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




        // Implement the finalizer to release unmanaged resources
        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion

















    }
}