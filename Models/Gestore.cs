using System;
using System.Collections.Generic;

namespace PTNF.Models;

public partial class Gestore
{
    public int GestorId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<GestorSaldo> GestorSaldos { get; set; } = new List<GestorSaldo>();
}
