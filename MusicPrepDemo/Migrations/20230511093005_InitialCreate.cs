using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicPrepDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afspeellijsten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naam = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afspeellijsten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artiesten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naam = table.Column<string>(type: "text", nullable: false),
                    Land = table.Column<string>(type: "text", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiesten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titel = table.Column<string>(type: "text", nullable: false),
                    ReleaseDatum = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArtiestId = table.Column<int>(type: "integer", nullable: false),
                    AlbumCoverId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artiesten_ArtiestId",
                        column: x => x.ArtiestId,
                        principalTable: "Artiesten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumCovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Afbeelding = table.Column<string>(type: "text", nullable: false),
                    AlbumId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumCovers_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nummers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titel = table.Column<string>(type: "text", nullable: false),
                    Lengte = table.Column<int>(type: "integer", nullable: false),
                    AlbumId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nummers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nummers_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AfspeellijstNummers",
                columns: table => new
                {
                    NummerId = table.Column<int>(type: "integer", nullable: false),
                    AfspeellijstId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfspeellijstNummers", x => new { x.NummerId, x.AfspeellijstId });
                    table.ForeignKey(
                        name: "FK_AfspeellijstNummers_Afspeellijsten_AfspeellijstId",
                        column: x => x.AfspeellijstId,
                        principalTable: "Afspeellijsten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AfspeellijstNummers_Nummers_NummerId",
                        column: x => x.NummerId,
                        principalTable: "Nummers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Afspeellijsten",
                columns: new[] { "Id", "Naam" },
                values: new object[,]
                {
                    { 1, "Rock Classics" },
                    { 2, "Electronic Hits" },
                    { 3, "Hip Hop Gems" }
                });

            migrationBuilder.InsertData(
                table: "Artiesten",
                columns: new[] { "Id", "Geboortedatum", "Land", "Naam" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UK", "The Beatles" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FR", "Stromae" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AU", "Bach" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "AlbumCoverId", "ArtiestId", "ReleaseDatum", "Titel" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abbey Road" },
                    { 2, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resolver" },
                    { 3, 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheese" },
                    { 4, 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Multitude" },
                    { 5, 5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sonata's" },
                    { 6, 6, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flute's" }
                });

            migrationBuilder.InsertData(
                table: "AlbumCovers",
                columns: new[] { "Id", "Afbeelding", "AlbumId" },
                values: new object[,]
                {
                    { 1, "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg", 1 },
                    { 2, "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg", 2 },
                    { 3, "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg", 3 },
                    { 4, "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg", 4 },
                    { 5, "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg", 5 },
                    { 6, "https://media.istockphoto.com/id/179250103/photo/live-music-background.jpg", 6 }
                });

            migrationBuilder.InsertData(
                table: "Nummers",
                columns: new[] { "Id", "AlbumId", "Lengte", "Titel" },
                values: new object[,]
                {
                    { 1, 1, 259, "Come Together" },
                    { 2, 1, 183, "Something" },
                    { 3, 2, 163, "Back in the USSR" },
                    { 4, 2, 254, "Dear Prudence" },
                    { 5, 3, 220, "Alors on danse" },
                    { 6, 3, 228, "Te Quiero" },
                    { 7, 4, 213, "Meltdown" },
                    { 8, 4, 229, "Papaoutai" },
                    { 9, 5, 287, "Sonata No. 1 in G minor" },
                    { 10, 5, 285, "Sonata No. 2 in A major" },
                    { 11, 6, 345, "Flute Sonata in E-flat major" },
                    { 12, 6, 208, "Flute Sonata in C major" }
                });

            migrationBuilder.InsertData(
                table: "AfspeellijstNummers",
                columns: new[] { "AfspeellijstId", "NummerId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 2, 0 },
                    { 1, 3, 0 },
                    { 2, 4, 0 },
                    { 1, 5, 0 },
                    { 2, 6, 0 },
                    { 1, 7, 0 },
                    { 2, 8, 0 },
                    { 3, 9, 0 },
                    { 3, 11, 0 },
                    { 3, 12, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfspeellijstNummers_AfspeellijstId",
                table: "AfspeellijstNummers",
                column: "AfspeellijstId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumCovers_AlbumId",
                table: "AlbumCovers",
                column: "AlbumId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtiestId",
                table: "Albums",
                column: "ArtiestId");

            migrationBuilder.CreateIndex(
                name: "IX_Nummers_AlbumId",
                table: "Nummers",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfspeellijstNummers");

            migrationBuilder.DropTable(
                name: "AlbumCovers");

            migrationBuilder.DropTable(
                name: "Afspeellijsten");

            migrationBuilder.DropTable(
                name: "Nummers");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artiesten");
        }
    }
}
