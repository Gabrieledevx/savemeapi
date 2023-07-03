using System;
using System.Collections.Generic;

namespace Saveme.Models;

public partial class Animalespecial
{
    public int Id { get; set; }

    public string? Especie { get; set; }

    public int? Edad { get; set; }

    public string? Tamano { get; set; }

    public string? Personalidad { get; set; }

    public string? Discapacidad { get; set; }

    public string? NecesidadesEspecialesAdicionales { get; set; }

    public virtual ICollection<Perfilanimalespecial> Perfilanimalespecials { get; set; } = new List<Perfilanimalespecial>();
}
