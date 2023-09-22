using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestingWebApp.Models;

public partial class Town
{
    [DisplayName("Town ID")]
    public int TownId { get; set; }

    [DisplayName("Town Name")]
    public string TownName { get; set; } = null!;

    public virtual ICollection<Organisation> Organisations { get; set; } = new List<Organisation>();
}
