using System;
using System.Collections.Generic;

namespace Saveme.Models;

public partial class Perfilanimal
{
    public int Id { get; set; }

    public int? AnimalId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Valoracion> Valoracions { get; set; } = new List<Valoracion>();
}
