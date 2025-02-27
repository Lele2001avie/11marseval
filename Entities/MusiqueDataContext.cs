using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Eval_11_mars.Entities;

public partial class MusiqueDataContext : DbContext
{
    public MusiqueDataContext()
    {
    }

    public MusiqueDataContext(DbContextOptions<MusiqueDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artisteinfo> Artisteinfos { get; set; }

    public virtual DbSet<Musique> Musiques { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    { optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password;database=musique_data"); }
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artisteinfo>(entity =>
        {
            entity.HasKey(e => e.IdArtiste);
            entity.ToTable("artisteinfo");

            entity.Property(e => e.AnneeNaissance)
                .HasColumnType("year")
                .HasColumnName("annee_naissance");
            entity.Property(e => e.IdArtiste)
                .HasMaxLength(255)
                .HasColumnName("id_artiste");
            entity.Property(e => e.Nationalite)
                .HasMaxLength(255)
                .HasColumnName("nationalite");
            entity.Property(e => e.Nom).HasMaxLength(255);
        });

        modelBuilder.Entity<Musique>(entity =>
        {
            entity.HasKey(e => e.IdArtiste);
            entity.ToTable("musique");

            entity.Property(e => e.Artiste).HasMaxLength(255);
            entity.Property(e => e.Chanson).HasMaxLength(255);
            entity.Property(e => e.DateDeSortie)
                .HasColumnType("year")
                .HasColumnName("Date_de_sortie");
            entity.Property(e => e.IdArtiste)
                .HasMaxLength(255)
                .HasColumnName("id_artiste");
            entity.Property(e => e.Langue)
                .HasMaxLength(255)
                .HasColumnName("langue");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
