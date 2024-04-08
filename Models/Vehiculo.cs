using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace gestor_crud_back.Models;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Anio { get; set; }

    public decimal? Precio { get; set; }

    [JsonIgnore]
    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}
