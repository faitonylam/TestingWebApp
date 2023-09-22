using TestingWebApp.Controllers;
using TestingWebApp.Services;
using TestingWebApp.Models;

using Moq;
using Xunit;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using TestingWebApp.DTOs;

namespace TestingWebApp.Tests
{
    public class OrganisationsControllerTest
    {
        [Fact]
        public async Task OrganisationsController_Index_Test()
        {
            //Arrange
            var skip = 6;
            var rowPerPage = 3;

            var testObject = new Organisation()
            {
                OrganisationNumber = "09740322",
                OrganisationName = "Barclays UK PLC",
                AddressLine1 = "1 Churchill Place ",
                TownId = 1,
                Postcode = "E14 5HP"
            };

            var mockOrganistaionService = new Mock<IOrganisationService>();
            var mockLogger = new Mock<ILogger<OrganisationsController>>();
            mockOrganistaionService.Setup(osvc => osvc.GetOrganisationCount())
                .ReturnsAsync(7);
            mockOrganistaionService.Setup(osvc => osvc.GetAllOrganisation(skip, rowPerPage))
                .ReturnsAsync(new List<Organisation>() { testObject });

            var controller = new OrganisationsController(mockOrganistaionService.Object, mockLogger.Object);

            //Act
            var result = await controller.Index(3);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<OrganisationListDTO>(viewResult.Model);
            Assert.NotNull(model);
            Assert.Single(model.Data);
        }

        [Theory]
        [InlineData(-1,1)]
        [InlineData(0,1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 3)]
        [InlineData(9, 3)]
        // Test the page number range
        public async Task OrganisationsController_Index_Test2(int page,int expected)
        {
            //Arrange
            var skip = 6;
            var rowPerPage = 3;

            var testObject = new Organisation()
            {
                OrganisationNumber = "09740322",
                OrganisationName = "Barclays UK PLC",
                AddressLine1 = "1 Churchill Place ",
                TownId = 1,
                Postcode = "E14 5HP"
            };

            var mockOrganistaionService = new Mock<IOrganisationService>();
            var mockLogger = new Mock<ILogger<OrganisationsController>>();
            mockOrganistaionService.Setup(osvc => osvc.GetOrganisationCount())
                .ReturnsAsync(7);
            mockOrganistaionService.Setup(osvc => osvc.GetAllOrganisation(skip, rowPerPage))
                .ReturnsAsync(new List<Organisation>() { testObject });

            var controller = new OrganisationsController(mockOrganistaionService.Object, mockLogger.Object);

            //Act
            var result = await controller.Index(page);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<OrganisationListDTO>(viewResult.Model);
            Assert.NotNull(model);
            Assert.Equal(expected, model.CurrentPage);
        }

        [Fact]
        public async Task OrganisationsController_Details_Test()
        {
            //Arrange
            var testObject = new Organisation() {
                OrganisationNumber = "09740322",
                OrganisationName = "Barclays UK PLC",
                AddressLine1 = "1 Churchill Place ",
                TownId = 1,
                Postcode = "E14 5HP"
            };

            var mockOrganistaionService = new Mock<IOrganisationService>();
            var mockLogger = new Mock<ILogger<OrganisationsController>>();

            mockOrganistaionService.Setup(osvc => osvc.GetOrganisationById(testObject.OrganisationNumber))
                .ReturnsAsync(testObject);

            var controller = new OrganisationsController(mockOrganistaionService.Object, mockLogger.Object);

            //Act
            var result = await controller.Details(testObject.OrganisationNumber);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Organisation>(viewResult.Model);
            Assert.Equal(testObject.OrganisationName,model.OrganisationName);
        }
    }
}