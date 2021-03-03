using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CaseManagementAPI_server.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<CaseStatus> CaseStatuses { get; set; }
        public virtual DbSet<CaseWorker> CaseWorkers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Case>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.CaseStatus)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CaseStatusId)
                    .HasConstraintName("FK__Cases__CaseStatu__403A8C7D");

                entity.HasOne(d => d.CaseWorker)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CaseWorkerId)
                    .HasConstraintName("FK__Cases__CaseWorke__3E52440B");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Cases__CustomerI__3F466844");
            });

            modelBuilder.Entity<CaseStatus>(entity =>
            {
                entity.ToTable("CaseStatus");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<CaseWorker>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CaseId)
                    .HasConstraintName("FK__Comments__CaseId__412EB0B6");

                entity.HasOne(d => d.CaseWorker)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CaseWorkerId)
                    .HasConstraintName("FK__Comments__CaseWo__4316F928");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Comments__Custom__4222D4EF");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.AddressLine).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
