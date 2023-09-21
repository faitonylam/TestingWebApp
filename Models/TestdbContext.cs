using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestingWebApp.Models;

public partial class TestdbContext : DbContext
{

    public TestdbContext(DbContextOptions<TestdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    public virtual DbSet<ViewOrganisation> ViewOrganisations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.OrganisationNumber).HasMaxLength(8);

            entity.HasOne(d => d.OrganisationNumberNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.OrganisationNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Organisation");
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.OrganisationNumber);

            entity.ToTable("Organisation");

            entity.Property(e => e.OrganisationNumber).HasMaxLength(8);
            entity.Property(e => e.AddressLine1).HasMaxLength(50);
            entity.Property(e => e.AddressLine2).HasMaxLength(50);
            entity.Property(e => e.AddressLine3).HasMaxLength(50);
            entity.Property(e => e.AddressLine4).HasMaxLength(50);
            entity.Property(e => e.OrganisationName).HasMaxLength(50);
            entity.Property(e => e.Postcode).HasMaxLength(8);
            entity.Property(e => e.TownId).HasColumnName("TownID");

            entity.HasOne(d => d.Town).WithMany(p => p.Organisations)
                .HasForeignKey(d => d.TownId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organisation_Town");
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.ToTable("Town");

            entity.Property(e => e.TownId).HasColumnName("TownID");
            entity.Property(e => e.TownName).HasMaxLength(50);
        });

        modelBuilder.Entity<ViewOrganisation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Organisation");

            entity.Property(e => e.AddressLine1).HasMaxLength(50);
            entity.Property(e => e.AddressLine2).HasMaxLength(50);
            entity.Property(e => e.AddressLine3).HasMaxLength(50);
            entity.Property(e => e.AddressLine4).HasMaxLength(50);
            entity.Property(e => e.OrganisationName).HasMaxLength(50);
            entity.Property(e => e.OrganisationNumber).HasMaxLength(8);
            entity.Property(e => e.Postcode).HasMaxLength(8);
            entity.Property(e => e.TownName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
