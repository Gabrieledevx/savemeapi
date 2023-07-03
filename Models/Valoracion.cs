using System;
using System.Collections.Generic;

namespace Saveme.Models;

public partial class Valoracion
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? PerfilAnimalId { get; set; }

    public int? PerfilAnimalEspecialId { get; set; }

    public int? Puntuacion { get; set; }

    public string? ComentarioAdicional { get; set; }

    public virtual Perfilanimal? PerfilAnimal { get; set; }

    public virtual Perfilanimalespecial? PerfilAnimalEspecial { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
