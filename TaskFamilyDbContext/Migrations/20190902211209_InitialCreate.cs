using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskFamilyWeb.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    DigitalCode = table.Column<string>(nullable: true),
                    CharacterCode = table.Column<string>(nullable: true),
                    MarkRemoval = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FamilyId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FamilyId);
                    table.ForeignKey(
                        name: "FK_Families_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    MarkRemoval = table.Column<short>(nullable: false),
                    FamilyId = table.Column<int>(nullable: false),
                    Periodicity = table.Column<int>(nullable: false),
                    DateBegin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purses",
                columns: table => new
                {
                    PurseId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    MarkRemoval = table.Column<short>(nullable: false),
                    FamilyId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    Draft = table.Column<short>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purses", x => x.PurseId);
                    table.ForeignKey(
                        name: "FK_Purses_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purses_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    ToDoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Draft = table.Column<short>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FamilyId = table.Column<int>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    Complete = table.Column<short>(nullable: false),
                    FactDate = table.Column<DateTime>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    PriceResult = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ToDoId);
                    table.ForeignKey(
                        name: "FK_ToDos_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovesMoney",
                columns: table => new
                {
                    MoveMoneyId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PurseId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    InMove = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovesMoney", x => x.MoveMoneyId);
                    table.ForeignKey(
                        name: "FK_MovesMoney_Purses_PurseId",
                        column: x => x.PurseId,
                        principalTable: "Purses",
                        principalColumn: "PurseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_FamilyId",
                table: "Events",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_CurrencyId",
                table: "Families",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovesMoney_PurseId",
                table: "MovesMoney",
                column: "PurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purses_CurrencyId",
                table: "Purses",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Purses_FamilyId",
                table: "Purses",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_FamilyId",
                table: "ToDos",
                column: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MovesMoney");

            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "Purses");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
