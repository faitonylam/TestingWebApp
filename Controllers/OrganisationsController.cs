using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestingWebApp.DTOs;
using TestingWebApp.Models;
using TestingWebApp.Services;

namespace TestingWebApp.Controllers
{
    public class OrganisationsController : Controller
    {
        private readonly IOrganisationService _organisationService;
        private readonly ILogger<OrganisationsController> _logger;

        public OrganisationsController(IOrganisationService organisationService,ILogger<OrganisationsController> logger)
        {
            _organisationService = organisationService;
            _logger = logger;
        }

        // GET: Organisations
        public async Task<IActionResult> Index(int page = 1)
        {
            try { 
                var rowPerPage = 3;
                var skip = (page-1) * rowPerPage;
                var count = await _organisationService.GetOrganisationCount();
                var result = await _organisationService.GetAllOrganisation(skip, rowPerPage);

                OrganisationListDTO responce = new OrganisationListDTO()
                {
                    CurrentPage = page,
                    TotalPage = (int)Math.Ceiling( count / (float)rowPerPage ),
                    Data = result
                };

                return View(responce);
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500,"Some error occurred.");
            }
        }

        // GET: Organisations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                if (id == null || _organisationService == null)
                {
                    return NotFound();
                }

                var organisation = await _organisationService.GetOrganisationById(id);
                if (organisation == null)
                {
                    return NotFound();
                }

                return View(organisation);
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500,"Some error occurred.");
            }   
        }
    }
}
