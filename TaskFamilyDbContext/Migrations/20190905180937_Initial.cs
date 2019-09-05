using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskFamilyWeb.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    DigitalCode = table.Column<string>(nullable: true),
                    CharacterCode = table.Column<string>(nullable: true),
                    MarkRemoval = table.Column<short>(type: "bit(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    Period = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    BaseCurrencyId = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Multiplicity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => new { x.BaseCurrencyId, x.CurrencyId, x.Period });
                    table.ForeignKey(
                        name: "FK_CurrencyRates_currencies_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Families_currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    MarkRemoval = table.Column<short>(type: "bit(1)", nullable: false),
                    FamilyId = table.Column<int>(nullable: false),
                    Periodicity = table.Column<int>(nullable: false),
                    DateBegin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_events_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purses",
                columns: table => new
                {
                    PurseId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    MarkRemoval = table.Column<short>(type: "bit(1)", nullable: false),
                    FamilyId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    Draft = table.Column<short>(type: "bit(1)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purses", x => x.PurseId);
                    table.ForeignKey(
                        name: "FK_purses_currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purses_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "todos",
                columns: table => new
                {
                    ToDoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Draft = table.Column<short>(type: "bit(1)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FamilyId = table.Column<int>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    Complete = table.Column<short>(type: "bit(1)", nullable: false),
                    FactDate = table.Column<DateTime>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    PriceResult = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todos", x => x.ToDoId);
                    table.ForeignKey(
                        name: "FK_todos_Families_FamilyId",
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
                        name: "FK_MovesMoney_purses_PurseId",
                        column: x => x.PurseId,
                        principalTable: "purses",
                        principalColumn: "PurseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_CurrencyId",
                table: "CurrencyRates",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_events_FamilyId",
                table: "events",
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
                name: "IX_purses_CurrencyId",
                table: "purses",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_purses_FamilyId",
                table: "purses",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_todos_FamilyId",
                table: "todos",
                column: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "MovesMoney");

            migrationBuilder.DropTable(
                name: "todos");

            migrationBuilder.DropTable(
                name: "purses");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "currencies");
        }
    }
}
