using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportCenter.Migrations
{
    /// <inheritdoc />
    public partial class ModelGuncellemeleri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IletisimBilgisi",
                table: "Antrenorler");

            migrationBuilder.RenameColumn(
                name: "UzmanlikAlani",
                table: "Antrenorler",
                newName: "Uzmanlik");

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "Uyeler",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "SporProgramlari",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "SporProgramlari",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kategori",
                table: "SporProgramlari",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KatilimciSayisi",
                table: "SporProgramlari",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxKatilimci",
                table: "SporProgramlari",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturmaTarihi",
                table: "SporProgramlari",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notlar",
                table: "ProgramKatilimlari",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "Kullanicilar",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Ekipmanlar",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Miktar",
                table: "EkipmanKullanimlari",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Antrenorler",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "AdSoyad",
                table: "Antrenorler",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "Antrenorler",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Ozgecmis",
                table: "Antrenorler",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Antrenorler",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "KullaniciId",
                keyValue: 1,
                columns: new[] { "Aktif", "KullaniciAdi" },
                values: new object[] { true, "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "Uyeler");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "KatilimciSayisi",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "MaxKatilimci",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "OlusturmaTarihi",
                table: "SporProgramlari");

            migrationBuilder.DropColumn(
                name: "Notlar",
                table: "ProgramKatilimlari");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Ekipmanlar");

            migrationBuilder.DropColumn(
                name: "Miktar",
                table: "EkipmanKullanimlari");

            migrationBuilder.DropColumn(
                name: "AdSoyad",
                table: "Antrenorler");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "Antrenorler");

            migrationBuilder.DropColumn(
                name: "Ozgecmis",
                table: "Antrenorler");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Antrenorler");

            migrationBuilder.RenameColumn(
                name: "Uzmanlik",
                table: "Antrenorler",
                newName: "UzmanlikAlani");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Antrenorler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IletisimBilgisi",
                table: "Antrenorler",
                type: "TEXT",
                maxLength: 200,
                nullable: true);
        }
    }
}
