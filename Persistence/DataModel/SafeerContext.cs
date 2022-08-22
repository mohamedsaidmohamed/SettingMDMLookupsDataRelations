using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Persistence.DataModel
{
    public partial class SafeerContext : DbContext
    {
        private readonly IConfiguration _iConfiguration;
        private readonly string _connectionString;
        public SafeerContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iConfiguration = builder.Build();
            _connectionString = _iConfiguration.GetConnectionString("MDMConnectionString");

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
                 optionsBuilder.UseSqlServer(_connectionString);
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
