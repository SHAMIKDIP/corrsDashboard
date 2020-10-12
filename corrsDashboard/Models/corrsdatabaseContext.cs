﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace corrsDashboard.Models
{
    public partial class corrsdatabaseContext : DbContext
    {
        public corrsdatabaseContext()
        {
        }

        public corrsdatabaseContext(DbContextOptions<corrsdatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Configurationmaster> Configurationmaster { get; set; }
        public virtual DbSet<Corrsmetricreasoncodedependency> Corrsmetricreasoncodedependency { get; set; }
        public virtual DbSet<Corrsmetrics> Corrsmetrics { get; set; }
        public virtual DbSet<Corrsplantdomains> Corrsplantdomains { get; set; }
        public virtual DbSet<Corrsplantmetricdependency> Corrsplantmetricdependency { get; set; }
        public virtual DbSet<Corrsplants> Corrsplants { get; set; }
        public virtual DbSet<Dateview> Dateview { get; set; }
        public virtual DbSet<Metricbasedreasoncodeview> Metricbasedreasoncodeview { get; set; }
        public virtual DbSet<Metricplantdomainview> Metricplantdomainview { get; set; }
        public virtual DbSet<Metricsview> Metricsview { get; set; }
        public virtual DbSet<PgBuffercache> PgBuffercache { get; set; }
        public virtual DbSet<PgStatStatements> PgStatStatements { get; set; }
        public virtual DbSet<Plantslist> Plantslist { get; set; }
        public virtual DbSet<Plantslist1> Plantslist1 { get; set; }
        public virtual DbSet<ReasonCodes> ReasonCodes { get; set; }
        public virtual DbSet<ShopFloorComformance> ShopFloorComformance { get; set; }
        public virtual DbSet<Shopfloorcomformanceview> Shopfloorcomformanceview { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseNpgsql("Server=corrsserver.postgres.database.azure.com;Database=corrsdatabase;Username=sqladmin@corrsserver;Password=Infy@12345;Integrated Security=True;SslMode=Require");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements");

            modelBuilder.Entity<Configurationmaster>(entity =>
            {
                entity.ToTable("configurationmaster", "corrs");

                entity.HasIndex(e => e.MetricId)
                    .HasName("fki_fk_metricid");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DbFileName).HasMaxLength(100);

                entity.Property(e => e.DeletedFileName).HasMaxLength(100);

                entity.Property(e => e.DeletedFolderPath).HasMaxLength(100);

                entity.Property(e => e.DeletedRoot).HasMaxLength(100);

                entity.Property(e => e.DuplicateFileName).HasMaxLength(100);

                entity.Property(e => e.DuplicateFolderPath).HasMaxLength(100);

                entity.Property(e => e.DuplicateRoot).HasMaxLength(100);

                entity.Property(e => e.InputFileName).HasMaxLength(100);

                entity.Property(e => e.InputFolderPath).HasMaxLength(100);

                entity.Property(e => e.InputRoot).HasMaxLength(50);

                entity.Property(e => e.MetricTableName).HasMaxLength(50);

                entity.Property(e => e.ProcessedFileName).HasMaxLength(100);

                entity.Property(e => e.ProcessedFolderPath).HasMaxLength(100);

                entity.Property(e => e.ProcessedRoot).HasMaxLength(100);

                entity.Property(e => e.SftpfileName)
                    .HasColumnName("SFTPFileName")
                    .HasMaxLength(100);

                entity.Property(e => e.SftpfilePath)
                    .HasColumnName("SFTPFilePath")
                    .HasMaxLength(100);

                entity.Property(e => e.SftphostName)
                    .HasColumnName("SFTPHostName")
                    .HasMaxLength(100);

                entity.Property(e => e.SftpuserName)
                    .HasColumnName("SFTPUserName")
                    .HasMaxLength(50);

                entity.Property(e => e.SheetName).HasMaxLength(100);

                entity.Property(e => e.StageFileName).HasMaxLength(100);

                entity.Property(e => e.StageFolderPath).HasMaxLength(100);

                entity.Property(e => e.StageRoot).HasMaxLength(50);

                entity.Property(e => e.SuccessFileName).HasMaxLength(100);

                entity.Property(e => e.SuccessFolderPath).HasMaxLength(100);

                entity.Property(e => e.SuccessRoot).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.Metric)
                    .WithMany(p => p.Configurationmaster)
                    .HasForeignKey(d => d.MetricId)
                    .HasConstraintName("fk_metricid");
            });

            modelBuilder.Entity<Corrsmetricreasoncodedependency>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("corrsmetricreasoncodedependency", "corrs");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.Metric)
                    .WithMany()
                    .HasForeignKey(d => d.MetricId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_metricId");

                entity.HasOne(d => d.Reason)
                    .WithMany()
                    .HasForeignKey(d => d.ReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reasoncodeid");
            });

            modelBuilder.Entity<Corrsmetrics>(entity =>
            {
                entity.HasKey(e => e.MetricId)
                    .HasName("pk_metricid");

                entity.ToTable("corrsmetrics", "corrs");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.MetricName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.MetricType).HasMaxLength(100);

                entity.Property(e => e.TargetCondition).HasMaxLength(300);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<Corrsplantdomains>(entity =>
            {
                entity.HasKey(e => e.DomainCode)
                    .HasName("pk_plantdomain");

                entity.ToTable("corrsplantdomains", "corrs");

                entity.HasIndex(e => e.DomainCode)
                    .HasName("corrsplantdomains_DomainCode_key")
                    .IsUnique();

                entity.Property(e => e.DomainCode).HasMaxLength(50);

                entity.Property(e => e.DomainId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Corrsplantmetricdependency>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("corrsplantmetricdependency", "corrs");

                entity.HasIndex(e => e.PlantDomain)
                    .HasName("fki_fk_plantId");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PlantDomain).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.MetricCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MetricCode)
                    .HasConstraintName("fk_metricid");

                entity.HasOne(d => d.PlantDomainNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PlantDomain)
                    .HasConstraintName("fk_plantdomain");
            });

            modelBuilder.Entity<Corrsplants>(entity =>
            {
                entity.HasKey(e => e.PlantId)
                    .HasName("pk_plantid");

                entity.ToTable("corrsplants", "corrs");

                entity.HasIndex(e => e.PlantDomain)
                    .HasName("fki_fk_domaincode");

                entity.Property(e => e.PlantId).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PlantDomain)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlantName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.PlantDomainNavigation)
                    .WithMany(p => p.Corrsplants)
                    .HasForeignKey(d => d.PlantDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_domaincode");
            });

            modelBuilder.Entity<Dateview>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dateview");

                entity.Property(e => e.Dateinterval)
                    .HasColumnName("dateinterval")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Metricbasedreasoncodeview>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("metricbasedreasoncodeview", "corrs");

                entity.Property(e => e.MetricName).HasMaxLength(300);

                entity.Property(e => e.ReasonCode).HasMaxLength(200);
            });

            modelBuilder.Entity<Metricplantdomainview>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("metricplantdomainview", "corrs");

                entity.Property(e => e.PlantDomain).HasMaxLength(50);
            });

            modelBuilder.Entity<Metricsview>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("metricsview", "corrs");

                entity.Property(e => e.MetricName).HasMaxLength(300);

                entity.Property(e => e.MetricType).HasMaxLength(100);

                entity.Property(e => e.PlantDomain).HasMaxLength(50);

                entity.Property(e => e.PlantId).HasMaxLength(50);

                entity.Property(e => e.TargetCondition).HasMaxLength(300);
            });

            modelBuilder.Entity<PgBuffercache>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_buffercache");

                entity.Property(e => e.Bufferid).HasColumnName("bufferid");

                entity.Property(e => e.Isdirty).HasColumnName("isdirty");

                entity.Property(e => e.PinningBackends).HasColumnName("pinning_backends");

                entity.Property(e => e.Relblocknumber).HasColumnName("relblocknumber");

                entity.Property(e => e.Reldatabase)
                    .HasColumnName("reldatabase")
                    .HasColumnType("oid");

                entity.Property(e => e.Relfilenode)
                    .HasColumnName("relfilenode")
                    .HasColumnType("oid");

                entity.Property(e => e.Relforknumber).HasColumnName("relforknumber");

                entity.Property(e => e.Reltablespace)
                    .HasColumnName("reltablespace")
                    .HasColumnType("oid");

                entity.Property(e => e.Usagecount).HasColumnName("usagecount");
            });

            modelBuilder.Entity<PgStatStatements>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnName("dbid")
                    .HasColumnType("oid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("oid");
            });

            modelBuilder.Entity<Plantslist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plantslist");

                entity.Property(e => e.PlantDomain).HasMaxLength(50);

                entity.Property(e => e.PlantId).HasMaxLength(50);

                entity.Property(e => e.PlantName).HasMaxLength(255);
            });

            modelBuilder.Entity<Plantslist1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plantslist", "corrs");

                entity.Property(e => e.PlantDomain).HasMaxLength(50);

                entity.Property(e => e.PlantId).HasMaxLength(50);

                entity.Property(e => e.PlantName).HasMaxLength(255);
            });

            modelBuilder.Entity<ReasonCodes>(entity =>
            {
                entity.HasKey(e => e.ReasonCodeId)
                    .HasName("pk_reasoncode");

                entity.ToTable("ReasonCodes", "corrs");

                entity.HasIndex(e => e.ReasonCode)
                    .HasName("unq_reasoncode")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ReasonCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            });

            modelBuilder.Entity<ShopFloorComformance>(entity =>
            {
                entity.HasKey(e => new { e.Resource, e.ProcessOrder })
                    .HasName("pk_primarykey");

                entity.ToTable("ShopFloorComformance", "corrs");

                entity.HasIndex(e => e.ReasonCode)
                    .HasName("fki_fk_reasoncode");

                entity.HasIndex(e => e.Week)
                    .HasName("fki_fk_week");

                entity.Property(e => e.Resource).HasMaxLength(50);

                entity.Property(e => e.BatchId).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FinishDateConfirmed).HasColumnType("date");

                entity.Property(e => e.FinishDateScheduled).HasColumnType("date");

                entity.Property(e => e.Flag).HasMaxLength(20);

                entity.Property(e => e.MaterialId).HasMaxLength(20);

                entity.Property(e => e.MaterialName).HasMaxLength(255);

                entity.Property(e => e.MrpcontrollerId)
                    .HasColumnName("MRPControllerId")
                    .HasMaxLength(20);

                entity.Property(e => e.MrpcontrollerName)
                    .HasColumnName("MRPControllerName")
                    .HasMaxLength(255);

                entity.Property(e => e.OrderQuantityUnit).HasMaxLength(20);

                entity.Property(e => e.PlantId).HasMaxLength(50);

                entity.Property(e => e.PlantName).HasMaxLength(255);

                entity.Property(e => e.Quarter).HasMaxLength(20);

                entity.Property(e => e.ReasonCode).HasMaxLength(200);

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.ShopFloorComformance)
                    .HasForeignKey(d => d.PlantId)
                    .HasConstraintName("fk_plantcode");

                entity.HasOne(d => d.ReasonCodeNavigation)
                    .WithMany(p => p.ShopFloorComformance)
                    .HasPrincipalKey(p => p.ReasonCode)
                    .HasForeignKey(d => d.ReasonCode)
                    .HasConstraintName("fk_reasoncode");
            });

            modelBuilder.Entity<Shopfloorcomformanceview>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shopfloorcomformanceview", "corrs");

                entity.Property(e => e.BatchId).HasMaxLength(20);

                entity.Property(e => e.FinishDateConfirmed).HasColumnType("date");

                entity.Property(e => e.FinishDateScheduled).HasColumnType("date");

                entity.Property(e => e.Flag).HasMaxLength(20);

                entity.Property(e => e.MaterialId).HasMaxLength(20);

                entity.Property(e => e.MaterialName).HasMaxLength(255);

                entity.Property(e => e.MrpcontrollerId)
                    .HasColumnName("MRPControllerId")
                    .HasMaxLength(20);

                entity.Property(e => e.MrpcontrollerName)
                    .HasColumnName("MRPControllerName")
                    .HasMaxLength(255);

                entity.Property(e => e.OrderQuantityUnit).HasMaxLength(20);

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(50);

                entity.Property(e => e.PlantDomain).HasMaxLength(50);

                entity.Property(e => e.PlantId).HasMaxLength(50);

                entity.Property(e => e.PlantName).HasMaxLength(255);

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasMaxLength(255);

                entity.Property(e => e.Quarter).HasMaxLength(20);

                entity.Property(e => e.Resource).HasMaxLength(50);

                entity.Property(e => e.ResourceName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
