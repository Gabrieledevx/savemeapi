using System;
using System.Collections.Generic;

namespace Saveme.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Adopcion> Adopcions { get; set; } = new List<Adopcion>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Donacion> Donacions { get; set; } = new List<Donacion>();

    public virtual ICollection<Participanteevento> Participanteeventos { get; set; } = new List<Participanteevento>();

    public virtual ICollection<Perfilanimalespecial> Perfilanimalespecials { get; set; } = new List<Perfilanimalespecial>();

    public virtual ICollection<Perfilanimal> Perfilanimals { get; set; } = new List<Perfilanimal>();

    public virtual ICollection<Valoracion> Valoracions { get; set; } = new List<Valoracion>();
}
