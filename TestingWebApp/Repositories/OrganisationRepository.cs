using Microsoft.EntityFrameworkCore;

namespace TestingWebApp.Repositories
{
    public class OrganisationRepository : GenericRepository<Organisation>, IOrganisationRepository

    {
        public OrganisationRepository(TestdbContext context) : base(context)
        {
        }

        public async Task<List<Organisation>> GetAllwithEmployees(int skip, int take)
        {
            return await _context.Organisations.OrderBy(o => o.OrganisationNumber)
                .Skip(skip)
                .Take(take)
                .Include(o => o.Town)
                .Include(o => o.Employees)
                .ToListAsync();
        }

        public async Task<Organisation> GetByID(string organisationNumber)
        {
            return await _context.Organisations
                .Include(o => o.Town)
                .Include(o => o.Employees)
                .FirstOrDefaultAsync(a => a.OrganisationNumber == organisationNumber);
        }
    }
}
