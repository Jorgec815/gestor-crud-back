using System;
using System.Collections.Generic;

namespace gestor_crud_back.Models;

public partial class Transacciones
{
    public int TransaccionId { get; set; }

    public int? VehiculoId { get; set; }

    public int? ClienteId { get; set; }

    public int? ConcesionarioId { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal? PrecioVenta { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Concesionario? Concesionario { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
