using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PROGETTO_U5_S1_L5.Models;

namespace PROGETTO_U5_S1_L5.Data;

public partial class ApplicationDbContext : DbContext {
    public ApplicationDbContext() {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
    }

    public virtual DbSet<Anagrafica> Anagraficas {
        get; set;
    }

    public virtual DbSet<TipoViolazione> TipoViolaziones {
        get; set;
    }

    public virtual DbSet<Verbale> Verbales {
        get; set;
    }

    public virtual DbSet<VerbaleViolazione> VerbaleViolaziones {
        get; set;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Super_Potenza\\SQLEXPRESS;Database=PROGETTO_U4_S3_L5;User Id=sa;Password=sa;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Anagrafica>(entity => {
            entity.HasKey(e => e.Idanagrafica).HasName("PK__ANAGRAFI__CC5AD936B99FEADB");
        });

        modelBuilder.Entity<TipoViolazione>(entity => {
            entity.HasKey(e => e.Idviolazione).HasName("PK__TIPO_VIO__9074BAE523BA9D6C");
        });

        modelBuilder.Entity<Verbale>(entity => {
            entity.HasKey(e => e.Idverbale).HasName("PK__VERBALE__4EE2293162C1EAF6");

            entity.HasOne(d => d.IdanagraficaNavigation).WithMany(p => p.Verbales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VERBALE_IDAnagrafica");
        });

        modelBuilder.Entity<VerbaleViolazione>(entity => {
            entity.HasKey(e => e.IdverbaleViolazione).HasName("PK__VERBALE___E97DE474A544D9C6");

            entity.HasOne(d => d.IdverbaleNavigation).WithMany(p => p.VerbaleViolaziones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VERBALEVIOLAZIONE_IDVerbale");

            entity.HasOne(d => d.IdviolazioneNavigation).WithMany(p => p.VerbaleViolaziones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VERBALEVIOLAZIONE_IDViolazione");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
