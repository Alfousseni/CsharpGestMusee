using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MuseeApps.Entities
{
    public partial class MuseeContext : DbContext
    {
        public MuseeContext()
            : base("name=MuseeContext")
        {
        }

        public virtual DbSet<artiste> artistes { get; set; }
        public virtual DbSet<billet> billets { get; set; }
        public virtual DbSet<employe> employes { get; set; }
        public virtual DbSet<exposition> expositions { get; set; }
        public virtual DbSet<oeuvre> oeuvres { get; set; }
        public virtual DbSet<oeuvres_expositions> oeuvres_expositions { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<visiteur> visiteurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<artiste>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<artiste>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<artiste>()
                .Property(e => e.Nationalite)
                .IsUnicode(false);

            modelBuilder.Entity<artiste>()
                .Property(e => e.Biographie)
                .IsUnicode(false);

            modelBuilder.Entity<artiste>()
                .HasMany(e => e.oeuvres)
                .WithOptional(e => e.artiste)
                .HasForeignKey(e => e.ID_Artiste);

            modelBuilder.Entity<billet>()
                .Property(e => e.Type_billet)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.telephone)
                .IsUnicode(false);

            modelBuilder.Entity<exposition>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<exposition>()
                .Property(e => e.heurDebut)
                .IsUnicode(false);

            modelBuilder.Entity<exposition>()
                .Property(e => e.heurFin)
                .IsUnicode(false);

            modelBuilder.Entity<exposition>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<exposition>()
                .HasMany(e => e.billets)
                .WithOptional(e => e.exposition)
                .HasForeignKey(e => e.ID_Exposition);

            modelBuilder.Entity<exposition>()
                .HasMany(e => e.oeuvres_expositions)
                .WithOptional(e => e.exposition)
                .HasForeignKey(e => e.ID_Exposition);

            modelBuilder.Entity<oeuvre>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<oeuvre>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<oeuvre>()
                .HasMany(e => e.oeuvres_expositions)
                .WithOptional(e => e.oeuvre)
                .HasForeignKey(e => e.ID_Oeuvre);


            modelBuilder.Entity<user>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.artistes)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.ID_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.billets)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.ID_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.expositions)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.ID_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.oeuvres)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.ID_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.visiteurs)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.ID_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<visiteur>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<visiteur>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<visiteur>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<visiteur>()
                .HasMany(e => e.billets)
                .WithOptional(e => e.visiteur)
                .HasForeignKey(e => e.ID_Visiteur);
        }
    }
}
