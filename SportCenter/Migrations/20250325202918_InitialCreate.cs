using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportCenter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ekipmanlar",
                columns: table => new
                {
                    EkipmanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EkipmanAdi = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Durum = table.Column<int>(type: "INTEGER", nullable: false),
                    Konum = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekipmanlar", x => x.EkipmanId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciTipi = table.Column<int>(type: "INTEGER", nullable: false),
                    Ad = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Sifre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Antrenorler",
                columns: table => new
                {
                    AntrenorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false),
                    UzmanlikAlani = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IletisimBilgisi = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenorler", x => x.AntrenorId);
                    table.ForeignKey(
                        name: "FK_Antrenorler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    UyeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Adres = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.UyeId);
                    table.ForeignKey(
                        name: "FK_Uyeler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SporProgramlari",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramAdi = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Saat = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    AntrenorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SporProgramlari", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_SporProgramlari_Antrenorler_AntrenorId",
                        column: x => x.AntrenorId,
                        principalTable: "Antrenorler",
                        principalColumn: "AntrenorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EkipmanKullanimlari",
                columns: table => new
                {
                    KullanimId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramId = table.Column<int>(type: "INTEGER", nullable: false),
                    EkipmanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkipmanKullanimlari", x => x.KullanimId);
                    table.ForeignKey(
                        name: "FK_EkipmanKullanimlari_Ekipmanlar_EkipmanId",
                        column: x => x.EkipmanId,
                        principalTable: "Ekipmanlar",
                        principalColumn: "EkipmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EkipmanKullanimlari_SporProgramlari_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "SporProgramlari",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramKatilimlari",
                columns: table => new
                {
                    KatilimId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UyeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProgramId = table.Column<int>(type: "INTEGER", nullable: false),
                    KatilimTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramKatilimlari", x => x.KatilimId);
                    table.ForeignKey(
                        name: "FK_ProgramKatilimlari_SporProgramlari_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "SporProgramlari",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramKatilimlari_Uyeler_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Uyeler",
                        principalColumn: "UyeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "KullaniciId", "Ad", "Email", "KayitTarihi", "KullaniciTipi", "Sifre", "Soyad" },
                values: new object[] { 1, "Admin", "admin@sportcenter.com", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Admin123!", "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Antrenorler_KullaniciId",
                table: "Antrenorler",
                column: "KullaniciId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EkipmanKullanimlari_EkipmanId",
                table: "EkipmanKullanimlari",
                column: "EkipmanId");

            migrationBuilder.CreateIndex(
                name: "IX_EkipmanKullanimlari_ProgramId",
                table: "EkipmanKullanimlari",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramKatilimlari_ProgramId",
                table: "ProgramKatilimlari",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramKatilimlari_UyeId",
                table: "ProgramKatilimlari",
                column: "UyeId");

            migrationBuilder.CreateIndex(
                name: "IX_SporProgramlari_AntrenorId",
                table: "SporProgramlari",
                column: "AntrenorId");

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_KullaniciId",
                table: "Uyeler",
                column: "KullaniciId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EkipmanKullanimlari");

            migrationBuilder.DropTable(
                name: "ProgramKatilimlari");

            migrationBuilder.DropTable(
                name: "Ekipmanlar");

            migrationBuilder.DropTable(
                name: "SporProgramlari");

            migrationBuilder.DropTable(
                name: "Uyeler");

            migrationBuilder.DropTable(
                name: "Antrenorler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
