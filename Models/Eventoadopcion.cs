using System;
using System.Collections.Generic;

namespace Saveme.Models;

public partial class Eventoadopcion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? UbicacionId { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual ICollection<Participanteevento> Participanteeventos { get; set; } = new List<Participanteevento>();

    public virtual Ubicacion? Ubicacion { get; set; }
}
