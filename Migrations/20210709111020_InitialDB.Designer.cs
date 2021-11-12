﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBSAnalytics.Models;

namespace TBSAnalytics.Migrations
{
    [DbContext(typeof(TBSContext))]
    [Migration("20210709111020_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TBSAnalytics.Models.Branch", b =>
                {
                    b.Property<string>("BrcCode")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("BrcName")
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("BrcRegion")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BrcStatus")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RMName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BrcCode");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("TBSAnalytics.Models.CardStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardMonth")
                        .HasColumnType("int");

                    b.Property<string>("CardType")
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("CardYear")
                        .HasColumnType("int");

                    b.Property<string>("CurAbv")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CustId")
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("NumberOfCards")
                        .HasColumnType("int");

                    b.Property<decimal>("OutstandingBal")
                        .HasColumnType("decimal(20,3)");

                    b.Property<decimal>("OutstandingBalUsd")
                        .HasColumnType("decimal(20,3)");

                    b.HasKey("Id");

                    b.HasIndex("CustId");

                    b.ToTable("CardStat");
                });

            modelBuilder.Entity("TBSAnalytics.Models.CardUsage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardMonth")
                        .HasColumnType("int");

                    b.Property<string>("CardType")
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("CardYear")
                        .HasColumnType("int");

                    b.Property<string>("CustId")
                        .HasColumnType("nvarchar(16)");

                    b.Property<decimal>("TrxAmountUsd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrxCount")
                        .HasColumnType("int");

                    b.Property<string>("TrxType")
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("CustId");

                    b.ToTable("CardSUsage");
                });

            modelBuilder.Entity("TBSAnalytics.Models.CurRate", b =>
                {
                    b.Property<string>("CurCode")
                        .HasColumnType("char(2)");

                    b.Property<string>("CurAbv")
                        .HasColumnType("char(5)");

                    b.Property<string>("CurISOCode")
                        .HasColumnType("char(3)");

                    b.Property<string>("CurName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("LBPRate")
                        .HasColumnType("decimal(20,9)");

                    b.Property<decimal>("USDRate")
                        .HasColumnType("decimal(20,9)");

                    b.HasKey("CurCode");

                    b.ToTable("CurRate");
                });

            modelBuilder.Entity("TBSAnalytics.Models.Customer", b =>
                {
                    b.Property<string>("CustId")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("BrcCode")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CustName")
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("CustStatus")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EcoSectId")
                        .HasColumnType("nvarchar(5)");

                    b.Property<bool>("Enrolled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EnrolledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MarketSegment")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServicePackage")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustId");

                    b.HasIndex("BrcCode");

                    b.HasIndex("EcoSectId");

                    b.HasIndex("EnrolledDate");

                    b.HasIndex("OpenDate");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TBSAnalytics.Models.DimDate", b =>
                {
                    b.Property<DateTime>("DateKey")
                        .HasColumnType("datetime2");

                    b.Property<int>("CalendarQuarter")
                        .HasColumnType("int");

                    b.Property<int>("CalendarSemester")
                        .HasColumnType("int");

                    b.Property<int>("CalendarYear")
                        .HasColumnType("int");

                    b.Property<string>("DayNameOfWeek")
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("DayNumberOfMonth")
                        .HasColumnType("int");

                    b.Property<int>("DayNumberOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("DayNumberOfYear")
                        .HasColumnType("int");

                    b.Property<string>("EnglishMonthName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("MonthNumberOfYear")
                        .HasColumnType("int");

                    b.Property<int>("WeekNumberOfYear")
                        .HasColumnType("int");

                    b.HasKey("DateKey");

                    b.ToTable("DimDate");
                });

            modelBuilder.Entity("TBSAnalytics.Models.EcoSector", b =>
                {
                    b.Property<string>("EcoSectId")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("EcoSectDesc")
                        .HasColumnType("nvarchar(225)");

                    b.HasKey("EcoSectId");

                    b.ToTable("EcoSector");
                });

            modelBuilder.Entity("TBSAnalytics.Models.Transaction", b =>
                {
                    b.Property<int>("TrxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("char(16)");

                    b.Property<string>("CustId")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Narration1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Narration2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TrxAmount")
                        .HasColumnType("decimal(20,3)");

                    b.Property<decimal>("TrxAmountUsd")
                        .HasColumnType("decimal(20,3)");

                    b.Property<string>("TrxChannel")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrxCurrency")
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("TrxDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrxRef")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("TrxSubType")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TrxSubTypeCount")
                        .HasColumnType("int");

                    b.Property<byte>("TrxTypeId")
                        .HasColumnType("tinyint");

                    b.HasKey("TrxId");

                    b.HasIndex("CustId");

                    b.HasIndex("TrxDate");

                    b.HasIndex("TrxTypeId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("TBSAnalytics.Models.TrxType", b =>
                {
                    b.Property<byte>("TrxTypeId")
                        .HasColumnType("tinyint");

                    b.Property<string>("TrxTypeDesc")
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("TrxTypeId");

                    b.ToTable("TrxType");
                });

            modelBuilder.Entity("TBSAnalytics.Models.CardStat", b =>
                {
                    b.HasOne("TBSAnalytics.Models.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustId");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TBSAnalytics.Models.CardUsage", b =>
                {
                    b.HasOne("TBSAnalytics.Models.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustId");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TBSAnalytics.Models.Customer", b =>
                {
                    b.HasOne("TBSAnalytics.Models.Branch", "Branch")
                        .WithMany("Customers")
                        .HasForeignKey("BrcCode");

                    b.HasOne("TBSAnalytics.Models.EcoSector", "EcoSectors")
                        .WithMany("Customers")
                        .HasForeignKey("EcoSectId");

                    b.HasOne("TBSAnalytics.Models.DimDate", "EnrolledDates")
                        .WithMany()
                        .HasForeignKey("EnrolledDate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBSAnalytics.Models.DimDate", "OpenDates")
                        .WithMany()
                        .HasForeignKey("OpenDate");

                    b.Navigation("Branch");

                    b.Navigation("EcoSectors");

                    b.Navigation("EnrolledDates");

                    b.Navigation("OpenDates");
                });

            modelBuilder.Entity("TBSAnalytics.Models.Transaction", b =>
                {
                    b.HasOne("TBSAnalytics.Models.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustId");

                    b.HasOne("TBSAnalytics.Models.DimDate", "TrxDates")
                        .WithMany("Transactions")
                        .HasForeignKey("TrxDate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBSAnalytics.Models.TrxType", "TrxTypes")
                        .WithMany("Transactions")
                        .HasForeignKey("TrxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("TrxDates");

                    b.Navigation("TrxTypes");
                });

            modelBuilder.Entity("TBSAnalytics.Models.Branch", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TBSAnalytics.Models.DimDate", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("TBSAnalytics.Models.EcoSector", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("TBSAnalytics.Models.TrxType", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
