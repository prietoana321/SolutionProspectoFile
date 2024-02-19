using System;
using System.Collections.Generic;

namespace AppProspecto.MODELS;

public partial class FileData
{
    public int IdFile { get; set; }

    public string? Name { get; set; }

    public string? Extension { get; set; }

    public string? MimeType { get; set; }

    public string? Path { get; set; }

    public int? IdProspecto { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ProspectoFile? IdProspectoNavigation { get; set; }
}
