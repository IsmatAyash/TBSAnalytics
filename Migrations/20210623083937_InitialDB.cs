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
                    TrxTypeDesc = table.Column<string>(type: "nvarchar(50)", nullable: true)
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
                    TrxRef = table.Column<string>(type: "char(10)", nullable: true),
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
