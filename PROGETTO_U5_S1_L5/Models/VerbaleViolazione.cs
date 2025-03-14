using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PROGETTO_U5_S1_L5.Models;

[Table("VERBALE_VIOLAZIONE")]
public partial class VerbaleViolazione
{
    [Key]
    [Column("IDVerbaleViolazione")]
    public int IdverbaleViolazione { get; set; }

    [Column("IDVerbale")]
    public int Idverbale { get; set; }

    [Column("IDViolazione")]
    public int Idviolazione { get; set; }

    [ForeignKey("Idverbale")]
    [InverseProperty("VerbaleViolaziones")]
    public virtual Verbale IdverbaleNavigation { get; set; } = null!;

    [ForeignKey("Idviolazione")]
    [InverseProperty("VerbaleViolaziones")]
    public virtual TipoViolazione IdviolazioneNavigation { get; set; } = null!;
}
