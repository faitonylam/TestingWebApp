using System.Drawing.Printing;

namespace TestingWebApp.Repositories
{
    public interface IDataRepositories : IDisposable
    {
        IOrganisationRepository Organisations { get; }
        int Save();
    }
}
