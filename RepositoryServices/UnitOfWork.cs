using DataAccessLayer;

using IRepositories;


namespace RepositoryServices
{
    public class UnitOfWork :  IUnitOfWork
    {

        public readonly ApplicationDbContext _context;

        public UnitOfWork( CategoryServess categoryServess , ApplicationDbContext _context , SubCategoryServess subCategoryServess   )

        {

            Icategory= categoryServess;
              this. _context= _context;  
              Isubcategory= subCategoryServess;


        }

        #region Implement the Dispose method to release resources
        private bool disposed = false;

        public Icategory Icategory { get; }
        public Isubcategory Isubcategory { get; }
 
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