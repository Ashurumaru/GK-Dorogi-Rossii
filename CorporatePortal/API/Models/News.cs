using System;
using System.Collections.Generic;

namespace API.Models;

public partial class News
{
    public int IdNew { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? CreateDate { get; set; }

    public int? IdTypeNew { get; set; }

    public int? IdCreator { get; set; }

    public virtual User? IdCreatorNavigation { get; set; }

    public virtual NewType? IdTypeNewNavigation { get; set; }
}
