﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PROGETTO_U5_S1_L5.Models;

[Table("VERBALE")]
public partial class Verbale
{
    [Key]
    [Column("IDVerbale")]
    public int Idverbale { get; set; }

    public DateOnly DataViolazione { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string IndirizzoViolazione { get; set; } = null!;

    [Column("Nominativo_Agente")]
    [StringLength(80)]
    [Unicode(false)]
    public string NominativoAgente { get; set; } = null!;

    public DateOnly DataTrascrizioneVerbale { get; set; }

    [Column(TypeName = "money")]
    public decimal Importo { get; set; }

    public int DecurtamentoPunti { get; set; }

    [Column("IDAnagrafica")]
    public int Idanagrafica { get; set; }

    [ForeignKey("Idanagrafica")]
    [InverseProperty("Verbales")]
    public virtual Anagrafica IdanagraficaNavigation { get; set; } = null!;

    [InverseProperty("IdverbaleNavigation")]
    public virtual ICollection<VerbaleViolazione> VerbaleViolaziones { get; set; } = new List<VerbaleViolazione>();
}
