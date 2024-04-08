using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace gestor_crud_back.Models;

public partial class Concesionario
{
    public int ConcesionarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    [JsonIgnore]
    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}
