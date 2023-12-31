﻿using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Animal
{
    public int Id { get; set; }

    public string? Especie { get; set; }

    public int? Edad { get; set; }

    public string? Tamano { get; set; }

    public string? Personalidad { get; set; }

    public string? NecesidadesEspeciales { get; set; }

    public virtual ICollection<Adopcion> Adopcions { get; set; } = new List<Adopcion>();

    public virtual ICollection<Rescate> Rescates { get; set; } = new List<Rescate>();

    public virtual ICollection<Visitasveterinario> Visitasveterinarios { get; set; } = new List<Visitasveterinario>();
}
