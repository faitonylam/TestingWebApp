using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestingWebApp.Models;

public partial class Organisation
{
    [DisplayName("Organisation Number")]
    public string OrganisationNumber { get; set; } = null!;

    [DisplayName("Organisation Name")]
    public string OrganisationName { get; set; } = null!;

    [DisplayName("Address Line 1")]
    public string AddressLine1 { get; set; } = null!;

    [DisplayName("Address Line 2")]
    public string? AddressLine2 { get; set; }

    [DisplayName("Address Line 3")]
    public string? AddressLine3 { get; set; }

    [DisplayName("Address Line 4")]
    public string? AddressLine4 { get; set; }

    [DisplayName("Town ID")]
    public int TownId { get; set; }

    [DisplayName("Postcode")]
    public string Postcode { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Town Town { get; set; } = null!;
}
