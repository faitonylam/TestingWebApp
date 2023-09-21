using Microsoft.EntityFrameworkCore;

namespace TestingWebApp.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly TestdbContext _context;

        public OrganisationService(TestdbContext context)
        {
            _context = context;
        }

        public async Task<List<Organisation>> GetAllOrganisation(int skip,int take)
        {
            var result = await _context.Organisations
                .Skip(skip)
                .Take(take)
                .Include(o => o.Town)
                .Include(o => o.Employees)
                .ToListAsync();

            return result;
        }

        public async Task<Organisation> GetOrganisationById(string id)
        {
            var result = await _context.Organisations.FirstOrDefaultAsync(a => a.OrganisationNumber == id);
            var organisation = await _context.Organisations
                .Include(o => o.Town)
                .Include(o => o.Employees)
                .FirstOrDefaultAsync(m => m.OrganisationNumber == id);

            return result;
        }

        public async Task<int> GetOrganisationCount()
        {
            var result = await _context.Organisations.CountAsync();
            return result;
        }
    }
}
