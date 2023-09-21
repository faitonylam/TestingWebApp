using System;
using System.Collections.Generic;

namespace TestingWebApp.Models;

public partial class ViewOrganisation
{
    public string OrganisationNumber { get; set; } = null!;

    public string OrganisationName { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? AddressLine4 { get; set; }

    public string? TownName { get; set; }

    public string Postcode { get; set; } = null!;

    public int? EmployeeCount { get; set; }
}
