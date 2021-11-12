using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBSAnalytics.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BrcCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    BrcName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    BrcRegion = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BrcStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RMName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BrcCode);
                });

            migrationBuilder.CreateTable(
                name: "CurRate",
                columns: table => new
                {
                    CurCode = table.Column<string>(type: "char(2)", nullable: false),
                    CurISOCode = table.Column<string>(type: "char(3)", nullable: true),
                    CurAbv = table.Column<string>(type: "char(5)", nullable: true),
                    CurName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LBPRate = table.Column<decimal>(type: "decimal(20,9)", nullable: false),
                    USDRate = table.Column<decimal>(type: "decimal(20,9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurRate", x => x.CurCode);
                });

            migrationBuilder.CreateTable(
                name: "DimDate",
                columns: table => new
                {
                    DateKey = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayNumberOfWeek = table.Column<int>(type: "int", nullable: false),
                    DayNameOfWeek = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    DayNumberOfMonth = table.Column<int>(type: "int", nullable: false),
                    DayNumberOfYear = table.Column<int>(type: "int", nullable: false),
                    WeekNumberOfYear = table.Column<int>(type: "int", nullable: false),
                    EnglishMonthName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    MonthNumberOfYear = table.Column<int>(type: "int", nullable: false),
                    CalendarQuarter = table.Column<int>(type: "int", nullable: false),
                    CalendarYear = table.Column<int>(type: "int", nullable: false),
                    CalendarSemester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDate", x => x.DateKey);
                });

            migrationBuilder.CreateTable(
                name: "EcoSector",
                columns: table => new
                {
                    EcoSectId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    EcoSectDesc = table.Column<string>(type: "nvarchar(225)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcoSector", x => x.EcoSectId);
                });

            migrationBuilder.CreateTable(
                name: "TrxType",
                columns: table => new
                {
                    TrxTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    TrxTypeDesc = table.Column<string>(type: "nvarchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrxType", x => x.TrxTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustId = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    CustName = table.Column<string>(type: "nvarchar(225)", nullable: true),
                    CustType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CustStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnrolledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enrolled = table.Column<bool>(type: "bit", nullable: false),
                    MarketSegment = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ServicePackage = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BrcCode = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    EcoSectId = table.Column<string>(type: "nvarchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustId);
                    table.ForeignKey(
                        name: "FK_Customer_Branch_BrcCode",
                        column: x => x.BrcCode,
                        principalTable: "Branch",
                        principalColumn: "BrcCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_DimDate_EnrolledDate",
                        column: x => x.EnrolledDate,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_DimDate_OpenDate",
                        column: x => x.OpenDate,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_EcoSector_EcoSectId",
                        column: x => x.EcoSectId,
                        principalTable: "EcoSector",
                        principalColumn: "EcoSectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardYear = table.Column<int>(type: "int", nullable: false),
                    CardMonth = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    CurAbv = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    NumberOfCards = table.Column<int>(type: "int", nullable: false),
                    OutstandingBal = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    OutstandingBalUsd = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    CustId = table.Column<string>(type: "nvarchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardStat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardStat_Customer_CustId",
                        column: x => x.CustId,
                        principalTable: "Customer",
                        principalColumn: "CustId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardSUsage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardYear = table.Column<int>(type: "int", nullable: false),
                    CardMonth = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    TrxType = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    TrxCount = table.Column<int>(type: "int", nullable: false),
                    TrxAmountUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustId = table.Column<string>(type: "nvarchar(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardSUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardSUsage_Customer_CustId",
                        column: x => x.CustId,
                        principalTable: "Customer",
                        principalColumn: "CustId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TrxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrxDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountNumber = table.Column<string>(type: "char(16)", nullable: true),
                    TrxChannel = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TrxCurrency = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    TrxAmount = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    TrxAmountUsd = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    Narration1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Narration2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrxRef = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    TrxSubType = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TrxSubTypeCount = table.Column<int>(type: "int", nullable: false),
                    CustId = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    TrxTypeId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TrxId);
                    table.ForeignKey(
                        name: "FK_Transaction_Customer_CustId",
                        column: x => x.CustId,
                        principalTable: "Customer",
                        principalColumn: "CustId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_DimDate_TrxDate",
                        column: x => x.TrxDate,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_TrxType_TrxTypeId",
                        column: x => x.TrxTypeId,
                        principalTable: "TrxType",
                        principalColumn: "TrxTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardStat_CustId",
                table: "CardStat",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_CardSUsage_CustId",
                table: "CardSUsage",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BrcCode",
                table: "Customer",
                column: "BrcCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EcoSectId",
                table: "Customer",
                column: "EcoSectId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EnrolledDate",
                table: "Customer",
                column: "EnrolledDate");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_OpenDate",
                table: "Customer",
                column: "OpenDate");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CustId",
                table: "Transaction",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TrxDate",
                table: "Transaction",
                column: "TrxDate");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TrxTypeId",
                table: "Transaction",
                column: "TrxTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardStat");

            migrationBuilder.DropTable(
                name: "CardSUsage");

            migrationBuilder.DropTable(
                name: "CurRate");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "TrxType");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "DimDate");

            migrationBuilder.DropTable(
                name: "EcoSector");
        }
    }
}
