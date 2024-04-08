using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace gestor_crud_back.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    [JsonIgnore]
    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}
