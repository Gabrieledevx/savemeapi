using System;
using System.Collections.Generic;

namespace Saveme.Models;

public partial class Proveedoradopcion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Ubicacion { get; set; }

    public string? InformacionVerificacion { get; set; }
}
