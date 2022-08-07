using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence.DataModel
{
    public partial class SafeerContext : DbContext
    {
        public SafeerContext()
        {
        }

        public SafeerContext(DbContextOptions<SafeerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<MinistryMajor> MinistryMajors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.34.95,1434; Initial Catalog=Safeer; User Id=saf2; Password=Safeer2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1256_CI_AS");

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major", "MDM");

                entity.HasIndex(e => e.BusinessCode, "IX_Major_BusinessCode");

                entity.Property(e => e.MajorArabicName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("MAJOR_ARABIC_NAME");

                entity.Property(e => e.MajorCode).HasColumnName("MAJOR_CODE");

                entity.Property(e => e.MajorEnglishName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("MAJOR_ENGLISH_NAME");

                entity.Property(e => e.MinistryMajorCode).HasColumnName("MINISTRY_MAJOR_CODE");
            });

            modelBuilder.Entity<MinistryMajor>(entity =>
            {
                entity.ToTable("MinistryMajor", "MDM");

                entity.Property(e => e.MinistryMajorArabicName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("MINISTRY_MAJOR_ARABIC_NAME");

                entity.Property(e => e.MinistryMajorCode).HasColumnName("MINISTRY_MAJOR_CODE");

                entity.Property(e => e.MinistryMajorEnglishName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("MINISTRY_MAJOR_ENGLISH_NAME");

                entity.Property(e => e.MinistryMajorFrenchName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("MINISTRY_MAJOR_FRENCH_NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
