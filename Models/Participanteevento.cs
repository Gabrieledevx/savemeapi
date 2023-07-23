using System;
using System.Collections.Generic;

namespace savemeapi.Models;

public partial class Participanteevento
{
    public int Id { get; set; }

    public int? EventoAdopcionId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Eventoadopcion? EventoAdopcion { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
