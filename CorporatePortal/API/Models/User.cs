using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? Patronymic { get; set; }

    public string? Email { get; set; }

    public int? IdDepartment { get; set; }

    public int? IdPosition { get; set; }

    public string? WorkNumber { get; set; }

    public string? HomeNumber { get; set; }

    public DateTime? BirthDay { get; set; }

    public string? PhotoPath { get; set; }

    public int? IdSwapper { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Department? IdDepartmentNavigation { get; set; }

    public virtual UserPosition? IdPositionNavigation { get; set; }

    public virtual User? IdSwapperNavigation { get; set; }

    public virtual ICollection<User> InverseIdSwapperNavigation { get; set; } = new List<User>();

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();

    public virtual ICollection<Event> IdEvents { get; set; } = new List<Event>();

    public virtual ICollection<Project> IdProjects { get; set; } = new List<Project>();
}
