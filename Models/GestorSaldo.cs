using System;
using System.Collections.Generic;

namespace PTNF.Models;

public partial class GestorSaldo
{
    public int GestorSaldoId { get; set; }

    public int? GestorId { get; set; }

    public int? CuentaId { get; set; }

    public virtual Cuenta? Cuenta { get; set; }

    public virtual Gestore? Gestor { get; set; }
}
