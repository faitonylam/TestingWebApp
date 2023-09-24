namespace TestingWebApp.Repositories
{
    public class DataRepositories : IDataRepositories
    {
        private readonly TestdbContext _context;

        public DataRepositories(TestdbContext context)
        {
            _context = context;
            Organisations = new OrganisationRepository(_context);
        }

        public IOrganisationRepository Organisations { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
