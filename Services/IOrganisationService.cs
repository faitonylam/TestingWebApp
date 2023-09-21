namespace TestingWebApp.Services
{
    public interface IOrganisationService
    {
        public Task<int> GetOrganisationCount();
        public Task<List<Organisation>> GetAllOrganisation(int skip,int take);
        public Task<Organisation> GetOrganisationById(string id);

    }
}
