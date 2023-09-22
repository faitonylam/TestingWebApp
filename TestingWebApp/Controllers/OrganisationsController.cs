using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Protocol;
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
            try
            {
                _logger.LogInformation("User [GET] Organisations");

                if (page <=0 )
                {
                    page = 1;
                }

                var rowPerPage = 3;
                
                var count = await _organisationService.GetOrganisationCount();

                OrganisationListDTO responce;

                if (count > 0)
                {
                    var totalPage = (int)Math.Ceiling(count / (float)rowPerPage);

                    if (page > totalPage)
                        page = totalPage;
                    
                    var skip = (page - 1) * rowPerPage;
                    var result = await _organisationService.GetAllOrganisation(skip, rowPerPage);

                    responce = new OrganisationListDTO()
                    {
                        CurrentPage = page,
                        TotalPage = totalPage,
                        Data = result
                    };

                    return View(responce);
                }
                else 
                {
                    responce = new OrganisationListDTO()
                    {
                        CurrentPage = page,
                        TotalPage = 0
                    };

                    return View(responce);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: Organisations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                _logger.LogInformation("User [GET] Organisations Details Id:{Id}", id);

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
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }   
        }
    }
}
