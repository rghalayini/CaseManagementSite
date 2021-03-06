﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CaseManagementAPI.Models
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

        public virtual DbSet<CaseStatus> CaseStatus { get; set; }
        public virtual DbSet<CaseWorkers> CaseWorkers { get; set; }
        public virtual DbSet<Cases> Cases { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseStatus>(entity =>
            {
                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<CaseWorkers>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Cases>(entity =>
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

            modelBuilder.Entity<Comments>(entity =>
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

            modelBuilder.Entity<Customers>(entity =>
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
