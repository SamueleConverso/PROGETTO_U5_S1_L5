using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PROGETTO_U5_S1_L5.Models;

[Table("TIPO_VIOLAZIONE")]
public partial class TipoViolazione
{
    [Key]
    [Column("IDViolazione")]
    public int Idviolazione { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Descrizione { get; set; } = null!;

    [InverseProperty("IdviolazioneNavigation")]
    public virtual ICollection<VerbaleViolazione> VerbaleViolaziones { get; set; } = new List<VerbaleViolazione>();
}
