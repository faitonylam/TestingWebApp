using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestingWebApp.Models;

public partial class Employee
{
    [DisplayName("Employee ID")]
    public int EmployeeId { get; set; }

    [DisplayName("First Name")]
    public string FirstName { get; set; } = null!;

    [DisplayName("Last Name")]
    public string LastName { get; set; } = null!;

    [DisplayName("Organisation Number")]
    public string OrganisationNumber { get; set; } = null!;

    public virtual Organisation OrganisationNumberNavigation { get; set; } = null!;
}
