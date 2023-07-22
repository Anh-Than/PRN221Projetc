using System;
using System.Collections.Generic;

namespace WPF_EF_SqlServer.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }
}
