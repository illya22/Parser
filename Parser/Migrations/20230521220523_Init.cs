using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parser.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartSubGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartGroupName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSubGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PartGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartGroupName = table.Column<string>(type: "TEXT", nullable: false),
                    SubPartGroupID = table.Column<int>(type: "INTEGER", nullable: false),
                    PartSubGroupID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartGroups_PartSubGroups_PartSubGroupID",
                        column: x => x.PartSubGroupID,
                        principalTable: "PartSubGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Engine1 = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    Grade = table.Column<string>(type: "TEXT", nullable: false),
                    ATM_MTM = table.Column<string>(type: "TEXT", nullable: false),
                    GearShiftType = table.Column<string>(type: "TEXT", nullable: false),
                    CAB = table.Column<string>(type: "TEXT", nullable: false),
                    TransmissionModel = table.Column<string>(type: "TEXT", nullable: false),
                    LoadingCapacity = table.Column<string>(type: "TEXT", nullable: false),
                    PartGroupID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConfigurationInfos_PartGroups_PartGroupID",
                        column: x => x.PartGroupID,
                        principalTable: "PartGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelName = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Configuration = table.Column<string>(type: "TEXT", nullable: false),
                    ConfigurationInfoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarModels_ConfigurationInfos_ConfigurationInfoID",
                        column: x => x.ConfigurationInfoID,
                        principalTable: "ConfigurationInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_ConfigurationInfoID",
                table: "CarModels",
                column: "ConfigurationInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationInfos_PartGroupID",
                table: "ConfigurationInfos",
                column: "PartGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PartGroups_PartSubGroupID",
                table: "PartGroups",
                column: "PartSubGroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "ConfigurationInfos");

            migrationBuilder.DropTable(
                name: "PartGroups");

            migrationBuilder.DropTable(
                name: "PartSubGroups");
        }
    }
}
