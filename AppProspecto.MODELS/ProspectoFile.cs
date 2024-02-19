﻿using System;
using System.Collections.Generic;

namespace AppProspecto.MODELS;

public partial class ProspectoFile
{
    public int IdProspecto { get; set; }

    public string? Nombre { get; set; }

    public string? Fachadaimg { get; set; }

    public string? Url { get; set; }

    public string? Direccion { get; set; }

    public string? Contacto { get; set; }

    public string? RazonSocial { get; set; }

    public int? Idauditor { get; set; }

    public string? Detalle { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<FileData> FileData { get; } = new List<FileData>();
}
