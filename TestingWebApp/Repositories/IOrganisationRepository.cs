namespace TestingWebApp.Repositories
{
    public interface IOrganisationRepository : IGenericRepository<Organisation>
    {
        Task<List<Organisation>> GetAllwithEmployees(int skip, int take);
        Task<Organisation> GetByID(string organisationNumber);
    }
}
