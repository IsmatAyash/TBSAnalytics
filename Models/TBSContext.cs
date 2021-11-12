using Microsoft.EntityFrameworkCore;
using System;

namespace TBSAnalytics.Models
{
    public class TBSContext : DbContext
    {
            public TBSContext(DbContextOptions<TBSContext> options) : base(options)
            {
            }

            public virtual DbSet<Branch> Branches { get; set; }
            public virtual DbSet<Customer> Customers { get; set; }
            public virtual DbSet<TrxType> TrxTypes { get; set; }
            public virtual DbSet<EcoSector> EcoSectors { get; set; }
            public virtual DbSet<Transaction> Transactions { get; set; }
            public virtual DbSet<DimDate> DimDates { get; set; }
            public virtual DbSet<CurRate> CusrRates { get; set; }
            public virtual DbSet<CardStat> CardStats { get; set; }
            public virtual DbSet<CardUsage> CardUsages { get; set; }
            public virtual DbSet<FFBalance> FFBalances { get; set; }
            public virtual DbSet<FFMonthlyBalance> FFMonthlyBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Branch>(entity => entity.ToTable("Branch"));
                modelBuilder.Entity<Customer>(entity => entity.ToTable("Customer"));
                modelBuilder.Entity<Transaction>(entity => entity.ToTable("Transaction"));
                modelBuilder.Entity<TrxType>(entity => entity.ToTable("TrxType"));
                modelBuilder.Entity<EcoSector>(entity => entity.ToTable("EcoSector"));
                modelBuilder.Entity<DimDate>(entity => entity.ToTable("DimDate"));
                modelBuilder.Entity<CurRate>(entity => entity.ToTable("CurRate"));
                modelBuilder.Entity<CardStat>(entity => entity.ToTable("CardStat"));
                modelBuilder.Entity<CardUsage>(entity => entity.ToTable("CardUsage"));
                modelBuilder.Entity<FFBalance>(entity => entity.ToTable("FFBalance"));
                modelBuilder.Entity<FFMonthlyBalance>(entity => entity.ToTable("FFMonthlyBalance"));
        }
    }
}
