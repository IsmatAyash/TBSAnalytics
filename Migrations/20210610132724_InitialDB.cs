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
                    BrcStatus = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BrcCode);
                });

            migrationBuilder.CreateTable(
                name: "EcoSector",
                columns: table => new
                {
                    EcoSectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    TrxTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrolledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enrolled = table.Column<bool>(type: "bit", nullable: false),
                    RMSegment = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ServicePackage = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BrcCode = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    EcoSectId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Customer_EcoSector_EcoSectId",
                        column: x => x.EcoSectId,
                        principalTable: "EcoSector",
                        principalColumn: "EcoSectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TrxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrxDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    TrxChannel = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TrxCurrency = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    TrxAmount = table.Column<decimal>(type: "decimal(38,3)", nullable: false),
                    TrxAmountUsd = table.Column<decimal>(type: "decimal(38,3)", nullable: false),
                    Narration1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Narration2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustId = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    TrxTypeId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Transaction_TrxType_TrxTypeId",
                        column: x => x.TrxTypeId,
                        principalTable: "TrxType",
                        principalColumn: "TrxTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "BrcCode", "BrcName", "BrcRegion", "BrcStatus" },
                values: new object[,]
                {
                    { "01", "Gefinor Branch", null, "Active" },
                    { "59", "GHAZIR", "North", "Active" },
                    { "58", "AMCHIT", "North", "Active" },
                    { "57", "RABIEH", "East", "Active" },
                    { "56", "DHOUR EL-CHOUEIR", "East", "Active" },
                    { "55", "DEKWANEH", "East", "Active" },
                    { "54", "BEIT EL CHAAR-AOUKAR", "East", "Active" },
                    { "60", "BASKINTA", "East", "Active" },
                    { "53", "CORNICHE EL-MAZRAA", "West", "Active" },
                    { "51", "SIDANI", "West", "Active" },
                    { "50", "FEYTROUN", "North", "Active" },
                    { "49", "KASLIK", "North", "Active" },
                    { "48", "ZOUK MOSBEH", "North", "Active" },
                    { "47", "TRIPOLI ABOU SAMRA            ", "North", "Active" },
                    { "44", "ALEY", "West", "Active" },
                    { "52", "BEIRUT PORT", "West", "Active" },
                    { "61", "CHEHABIYEH", "West", "Active" },
                    { "62", "ZOUK MICHAEL", "North", "Active" },
                    { "63", "DEIR EL ZAHRANI", "West", "Active" },
                    { "999", "NONE", "NONE", "Active" },
                    { "77", "CASINO BRANCH", "North", "Active" },
                    { "76", "ZAHLE", "West", "Active" },
                    { "75", "BCHARRE", "North", "Active" },
                    { "74", "SIN EL FIL-HAYEK", "East", "Active" },
                    { "73", "ACHKOUT", "North", "Active" },
                    { "72", "FARAYA", "North", "Active" },
                    { "71", "CHOUEIFAT", "West", "Active" },
                    { "70", "BAABDA", "East", "Active" },
                    { "69", "BATROUN", "North", "Active" },
                    { "68", "ACHRAFIEH-ATAYA", "East", "Active" },
                    { "67", "JBEIL - VOIE 13", "North", "Active" },
                    { "66", "SADAT", "West", "Active" },
                    { "65", "BAYADA-CORNET CHAHWAN", "East", "Active" },
                    { "64", "BALLOUNEH", "North", "Active" },
                    { "43", "TRIPOLI-BANKS STREET", "North", "Active" },
                    { "42", "JBEIL", "North", "Active" },
                    { "45", "CHTAURA", "West", "Active" },
                    { "39", "DORA", "East", "Active" },
                    { "17", "RAS BEIRUT", "West", "Active" },
                    { "41", "TYR-AL RAML", "West", "Active" },
                    { "15", "JDEIDEH", "East", "Active" },
                    { "14", "CHIAH", "West", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "BrcCode", "BrcName", "BrcRegion", "BrcStatus" },
                values: new object[,]
                {
                    { "13", "ANTELIAS", "East", "Active" },
                    { "11", "ACHRAFIEH - SIOUFI", "East", "Active" },
                    { "10", "BAUCHRIEH", "East", "Active" },
                    { "09", "TARIK EL JDIDEH", "West", "Active" },
                    { "08", "SIN EL FIL", "East", "Active" },
                    { "07", "JOUNIEH", "North", "Active" },
                    { "06", "NAHR", "East", "Active" },
                    { "05", "HAZMIEH", "East", "Active" },
                    { "04", "BROUMANA", "East", "Active" },
                    { "03", "MAR ELIAS", "West", "Active" },
                    { "02", "JAL EL DIB", "East", "Active" },
                    { "18", "HORCH TABET", "East", "Active" },
                    { "19", "ACHRAFIEH - SAYDEH", "East", "Active" },
                    { "16", "BOURJ HAMMOUD", "East", "Active" },
                    { "24", "KFARSAROUN", "North", "Active" },
                    { "38", "PALAIS DE JUSTICE", "East", "Active" },
                    { "37", "GHOBEIRY AIRPORT ROAD", "West", "Active" },
                    { "36", "HAMRA", "West", "Active" },
                    { "22", "MAZRAAT YACHOUH - ELYSSAR", "East", "Active" },
                    { "34", "RIYAD EL SOLH", "West", "Active" },
                    { "33", "FOCH", "West", "Active" },
                    { "32", "KORAYTEM", "West", "Active" },
                    { "35", "MAZRAA", "West", "Active" },
                    { "30", "SAIDA", "West", "Active" },
                    { "29", "AIN EL REMMANEH", "East", "Active" },
                    { "28", "SOUR", "West", "Active" },
                    { "27", "MANSOURIEH", "East", "Active" },
                    { "26", "JOUNIEH - GHADIR", "North", "Active" },
                    { "25", "JAL EL DIB SQUARE", "East", "Active" },
                    { "31", "MAZRAA - BARBIR               ", "WEST", "Active" }
                });

            migrationBuilder.InsertData(
                table: "EcoSector",
                columns: new[] { "EcoSectId", "EcoSectDesc" },
                values: new object[,]
                {
                    { 1, "Consultancy Services" },
                    { 2, "Travel Agency" },
                    { 3, "Information Technology (IT) Company" },
                    { 4, "Pharmaceutical / Medical Products" }
                });

            migrationBuilder.InsertData(
                table: "TrxType",
                columns: new[] { "TrxTypeId", "TrxTypeDesc" },
                values: new object[,]
                {
                    { 3, "Demand Draft" },
                    { 1, "Wires" },
                    { 2, "Transfers" },
                    { 4, "Port Bills" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustId", "BrcCode", "CustName", "CustStatus", "CustType", "EcoSectId", "Enrolled", "EnrolledDate", "OpenDate", "RMSegment", "ServicePackage" },
                values: new object[,]
                {
                    { "006066", "15", "NAUFAL GROUP S.A.R.L.", "Active", "Corporate", 1, true, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), "MMD", "Information Only" },
                    { "009744", "33", "AOUT PLUS SAL. AL", "Active", "Establishment", 1, true, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), "BBU", "Information Only" },
                    { "009680", "48", "COMPUTER & COMMUNICATIONSSYSTEMS INC.", "Active", "Corporate", 2, true, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), "BBU", "All Services Admin" },
                    { "009330", "74", "MDS EAST EUROPE LTD", "Active", "Corporate", 3, true, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), "CBD", "All Services User" },
                    { "600055", "74", "Osmat Ayash", "Active", "Establishment", 3, false, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), "", "" }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TrxId", "AccountNumber", "CustId", "Narration1", "Narration2", "TrxAmount", "TrxAmountUsd", "TrxChannel", "TrxCurrency", "TrxDate", "TrxTypeId" },
                values: new object[,]
                {
                    { 3, "1140200606600", "006066", "Narration 1", "", 4000m, 4000m, "OLB", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 6, "1140200933000", "009330", "Narration 1", "", 500m, 700m, "MOB", "EUR", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 21, "1140200968000", "009680", "Narration 1", "", 500m, 700m, "MOB", "EUR", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, "1140200968000", "009680", "Narration 1", "", 29991.29m, 29991.29m, "FCC", "USD", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, "1140200968000", "009680", "Narration 1", "", 500m, 700m, "MOB", "EUR", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, "1140200968000", "009680", "Narration 1", "", 29991.29m, 29991.29m, "FCC", "USD", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "1140200968000", "009680", "Narration 1", "", 500m, 700m, "MOB", "EUR", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 1, "1140200968000", "009680", "Narration 1", "", 29991.29m, 29991.29m, "FCC", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 12, "1140200974400", "009744", "Narration 1", "", 4500m, 4500m, "OLB", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 11, "1140200974400", "009744", "Narration 1", "", 900m, 900m, "BRC", "EUR", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 10, "1140200974400", "009744", "Narration 1", "", 400m, 400m, "BRC", "EUR", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 9, "1140200974400", "009744", "Narration 1", "", 600m, 800m, "MOB", "EUR", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 24, "1140200606600", "006066", null, "", 29991.29m, 29991.29m, "MOB", "USD", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 23, "1140200606600", "006066", "Narration 1", "", 5000m, 5000m, "FCC", "USD", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, "1140200606600", "006066", "Narration 1", "", 4000m, 4000m, "OLB", "USD", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, "1140200606600", "006066", null, "", 29991.29m, 29991.29m, "MOB", "USD", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 18, "1140200606600", "006066", "Narration 1", "", 5000m, 5000m, "FCC", "USD", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, "1140200606600", "006066", "Narration 1", "", 4000m, 4000m, "OLB", "USD", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, "1140200606600", "006066", null, "", 29991.29m, 29991.29m, "BRC", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 13, "1140200606600", "006066", "Narration 1", "", 8500m, 8500m, "BRC", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 5, "1140200606600", "006066", null, "", 29991.29m, 29991.29m, "MOB", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 4, "1140200606600", "006066", "Narration 1", "", 5000m, 5000m, "FCC", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 7, "1140200933000", "009330", "Narration 1", "", 4000m, 4000m, "OLB", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 8, "1140200933000", "009330", null, "", 5000m, 5000m, "FCC", "USD", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), 3 }
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
                name: "IX_Transaction_CustId",
                table: "Transaction",
                column: "CustId");

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
                name: "EcoSector");
        }
    }
}
