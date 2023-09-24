using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestingWebApp.Repositories;

namespace TestingWebApp.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IDataRepositories _dataRepo;

        public OrganisationService(IDataRepositories dataRepo)
        {
            _dataRepo = dataRepo;
        }

        public async Task<List<Organisation>?> GetAllOrganisation(int skip, int take)
        {
            if (_dataRepo.Organisations is null)
                return null;

            var result = await _dataRepo.Organisations.GetAllwithEmployees(skip, take);

            return result;
        }

        public async Task<Organisation> GetOrganisationById(string id)
        {
            if (_dataRepo.Organisations is null)
                return null;

            var result = await _dataRepo.Organisations.GetByID(id);

            return result;
        }

        public async Task<int> GetOrganisationCount()
        {
            if (_dataRepo.Organisations is null)
                return 0;

            var result = await _dataRepo.Organisations.GetAll();
            return result.Count();
        }
    }
}
