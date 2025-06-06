﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportCenter.Data;

#nullable disable

namespace SportCenter.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("SportCenter.Models.Antrenor", b =>
                {
                    b.Property<int>("AntrenorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aktif")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Deneyim")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IletisimBilgisi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KullaniciId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ozgecmis")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("UzmanlikAlani")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("AntrenorId");

                    b.HasIndex("KullaniciId")
                        .IsUnique();

                    b.HasIndex("KullaniciId1")
                        .IsUnique();

                    b.ToTable("Antrenorler");
                });

            modelBuilder.Entity("SportCenter.Models.Ekipman", b =>
                {
                    b.Property<int>("EkipmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("AlimTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("Durum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EkipmanAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Konum")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("SonBakimTarihi")
                        .HasColumnType("TEXT");

                    b.HasKey("EkipmanId");

                    b.ToTable("Ekipmanlar");
                });

            modelBuilder.Entity("SportCenter.Models.EkipmanKullanim", b =>
                {
                    b.Property<int>("KullanimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EkipmanId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KullanimMiktari")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KullanimTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notlar")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProgramId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KullanimId");

                    b.HasIndex("EkipmanId");

                    b.HasIndex("ProgramId");

                    b.ToTable("EkipmanKullanimlari");
                });

            modelBuilder.Entity("SportCenter.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Aktif")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("KullaniciTipi")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            KullaniciId = 1,
                            Ad = "Admin",
                            Aktif = true,
                            Email = "admin@sportcenter.com",
                            KayitTarihi = new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KullaniciAdi = "",
                            KullaniciTipi = 1,
                            Sifre = "Admin123!",
                            Soyad = "User"
                        });
                });

            modelBuilder.Entity("SportCenter.Models.ProgramKatilim", b =>
                {
                    b.Property<int>("KatilimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("KatilimDurumu")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KatilimTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notlar")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProgramId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UyeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KatilimId");

                    b.HasIndex("ProgramId");

                    b.HasIndex("UyeId");

                    b.ToTable("ProgramKatilimlari");
                });

            modelBuilder.Entity("SportCenter.Models.SporProgrami", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AntrenorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Durum")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Kategori")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("KatilimciSayisi")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxKatilimci")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OlusturmaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProgramAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("ProgramSaati")
                        .HasColumnType("TEXT");

                    b.HasKey("ProgramId");

                    b.HasIndex("AntrenorId");

                    b.ToTable("SporProgramlari");
                });

            modelBuilder.Entity("SportCenter.Models.Uye", b =>
                {
                    b.Property<int>("UyeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adres")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Aktif")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KullaniciId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("UyeId");

                    b.HasIndex("KullaniciId")
                        .IsUnique();

                    b.HasIndex("KullaniciId1")
                        .IsUnique();

                    b.ToTable("Uyeler");
                });

            modelBuilder.Entity("SportCenter.Models.Antrenor", b =>
                {
                    b.HasOne("SportCenter.Models.Kullanici", "Kullanici")
                        .WithOne()
                        .HasForeignKey("SportCenter.Models.Antrenor", "KullaniciId");

                    b.HasOne("SportCenter.Models.Kullanici", null)
                        .WithOne("Antrenor")
                        .HasForeignKey("SportCenter.Models.Antrenor", "KullaniciId1");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("SportCenter.Models.EkipmanKullanim", b =>
                {
                    b.HasOne("SportCenter.Models.Ekipman", "Ekipman")
                        .WithMany("EkipmanKullanimlari")
                        .HasForeignKey("EkipmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportCenter.Models.SporProgrami", "SporProgrami")
                        .WithMany("EkipmanKullanimlari")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ekipman");

                    b.Navigation("SporProgrami");
                });

            modelBuilder.Entity("SportCenter.Models.ProgramKatilim", b =>
                {
                    b.HasOne("SportCenter.Models.SporProgrami", "SporProgrami")
                        .WithMany("ProgramKatilimlari")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportCenter.Models.Uye", "Uye")
                        .WithMany("ProgramKatilimlari")
                        .HasForeignKey("UyeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SporProgrami");

                    b.Navigation("Uye");
                });

            modelBuilder.Entity("SportCenter.Models.SporProgrami", b =>
                {
                    b.HasOne("SportCenter.Models.Antrenor", "Antrenor")
                        .WithMany("SporProgramlari")
                        .HasForeignKey("AntrenorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Antrenor");
                });

            modelBuilder.Entity("SportCenter.Models.Uye", b =>
                {
                    b.HasOne("SportCenter.Models.Kullanici", "Kullanici")
                        .WithOne()
                        .HasForeignKey("SportCenter.Models.Uye", "KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportCenter.Models.Kullanici", null)
                        .WithOne("Uye")
                        .HasForeignKey("SportCenter.Models.Uye", "KullaniciId1");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("SportCenter.Models.Antrenor", b =>
                {
                    b.Navigation("SporProgramlari");
                });

            modelBuilder.Entity("SportCenter.Models.Ekipman", b =>
                {
                    b.Navigation("EkipmanKullanimlari");
                });

            modelBuilder.Entity("SportCenter.Models.Kullanici", b =>
                {
                    b.Navigation("Antrenor");

                    b.Navigation("Uye");
                });

            modelBuilder.Entity("SportCenter.Models.SporProgrami", b =>
                {
                    b.Navigation("EkipmanKullanimlari");

                    b.Navigation("ProgramKatilimlari");
                });

            modelBuilder.Entity("SportCenter.Models.Uye", b =>
                {
                    b.Navigation("ProgramKatilimlari");
                });
#pragma warning restore 612, 618
        }
    }
}
