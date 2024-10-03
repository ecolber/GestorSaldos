using System;
using System.Collections.Generic;

namespace PTNF.Models;

public partial class Cuenta
{
    public int CuentaId { get; set; }

    public string? NombreCta { get; set; }

    public decimal? Saldo { get; set; }

    public virtual ICollection<GestorSaldo> GestorSaldos { get; set; } = new List<GestorSaldo>();
}
