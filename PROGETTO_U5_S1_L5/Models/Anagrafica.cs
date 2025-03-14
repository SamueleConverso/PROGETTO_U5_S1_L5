using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PROGETTO_U5_S1_L5.Models;

[Table("ANAGRAFICA")]
public partial class Anagrafica
{
    [Key]
    [Column("IDAnagrafica")]
    public int Idanagrafica { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(40)]
    [Unicode(false)]
    public string Cognome { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Indirizzo { get; set; } = null!;

    [StringLength(40)]
    [Unicode(false)]
    public string Citta { get; set; } = null!;

    [Column("CAP")]
    public int Cap { get; set; }

    [Column("Cod_Fisc")]
    [StringLength(17)]
    [Unicode(false)]
    public string CodFisc { get; set; } = null!;

    [InverseProperty("IdanagraficaNavigation")]
    public virtual ICollection<Verbale> Verbales { get; set; } = new List<Verbale>();
}
