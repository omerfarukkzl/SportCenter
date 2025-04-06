using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportCenter.Migrations
{
    /// <inheritdoc />
    public partial class AdminPanelUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antrenorler_Kullanicilar_KullaniciId",
                table: "Antrenorler");

            migrationBuilder.DropColumn(
                name: "Saat",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Antrenorler");

            migrationBuilder.RenameColumn(
                name: "Miktar",
                table: "EkipmanKullanimlari",
                newName: "KullanimMiktari");

            migrationBuilder.RenameColumn(
                name: "Uzmanlik",
                table: "Antrenorler",
                newName: "UzmanlikAlani");

            migrationBuilder.RenameColumn(
                name: "AdSoyad",
                table: "Antrenorler",
                newName: "IletisimBilgisi");

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId1",
                table: "Uyeler",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KatilimciSayisi",
                table: "SporProgramlari",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Durum",
                table: "SporProgramlari",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "SporProgramlari",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ProgramSaati",
                table: "SporProgramlari",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "KatilimDurumu",
                table: "ProgramKatilimlari",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AlimTarihi",
                table: "Ekipmanlar",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonBakimTarihi",
                table: "Ekipmanlar",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KullanimTarihi",
                table: "EkipmanKullanimlari",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notlar",
                table: "EkipmanKullanimlari",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Deneyim",
                table: "Antrenorler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId1",
                table: "Antrenorler",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_KullaniciId1",
                table: "Uyeler",
                column: "KullaniciId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Antrenorler_KullaniciId1",
                table: "Antrenorler",
                column: "KullaniciId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Antrenorler_Kullanicilar_KullaniciId",
                table: "Antrenorler",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Antrenorler_Kullanicilar_KullaniciId1",
                table: "Antrenorler",
                column: "KullaniciId1",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uyeler_Kullanicilar_KullaniciId1",
                table: "Uyeler",
                column: "KullaniciId1",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antrenorler_Kullanicilar_KullaniciId",
                table: "Antrenorler");

            migrationBuilder.DropForeignKey(
                name: "FK_Antrenorler_Kullanicilar_KullaniciId1",
                table: "Antrenorler");

            migrationBuilder.DropForeignKey(
                name: "FK_Uyeler_Kullanicilar_KullaniciId1",
                table: "Uyeler");

            migrationBuilder.DropIndex(
                name: "IX_Uyeler_KullaniciId1",
                table: "Uyeler");

            migrationBuilder.DropIndex(
                name: "IX_Antrenorler_KullaniciId1",
                table: "Antrenorler");

            migrationBuilder.DropColumn(
                name: "KullaniciId1",
                table: "Uyeler");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "ProgramSaati",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "KatilimDurumu",
                table: "ProgramKatilimlari");

            migrationBuilder.DropColumn(
                name: "AlimTarihi",
                table: "Ekipmanlar");

            migrationBuilder.DropColumn(
                name: "SonBakimTarihi",
                table: "Ekipmanlar");

            migrationBuilder.DropColumn(
                name: "KullanimTarihi",
                table: "EkipmanKullanimlari");

            migrationBuilder.DropColumn(
                name: "Notlar",
                table: "EkipmanKullanimlari");

            migrationBuilder.DropColumn(
                name: "Deneyim",
                table: "Antrenorler");

            migrationBuilder.DropColumn(
                name: "KullaniciId1",
                table: "Antrenorler");

            migrationBuilder.RenameColumn(
                name: "KullanimMiktari",
                table: "EkipmanKullanimlari",
                newName: "Miktar");

            migrationBuilder.RenameColumn(
                name: "UzmanlikAlani",
                table: "Antrenorler",
                newName: "Uzmanlik");

            migrationBuilder.RenameColumn(
                name: "IletisimBilgisi",
                table: "Antrenorler",
                newName: "AdSoyad");

            migrationBuilder.AlterColumn<int>(
                name: "KatilimciSayisi",
                table: "SporProgramlari",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Durum",
                table: "SporProgramlari",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Saat",
                table: "SporProgramlari",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Antrenorler",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Antrenorler_Kullanicilar_KullaniciId",
                table: "Antrenorler",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
