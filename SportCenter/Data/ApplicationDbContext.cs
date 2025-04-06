using Microsoft.EntityFrameworkCore;
using SportCenter.Models;

namespace SportCenter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Antrenor> Antrenorler { get; set; }
        public DbSet<SporProgrami> SporProgramlari { get; set; }
        public DbSet<Ekipman> Ekipmanlar { get; set; }
        public DbSet<ProgramKatilim> ProgramKatilimlari { get; set; }
        public DbSet<EkipmanKullanim> EkipmanKullanimlari { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Üye-Kullanıcı ilişkisi (1-1)
            modelBuilder.Entity<Uye>()
                .HasOne(u => u.Kullanici)
                .WithOne()
                .HasForeignKey<Uye>(u => u.KullaniciId);
            
            // Antrenör-Kullanıcı ilişkisi (1-1)
            modelBuilder.Entity<Antrenor>()
                .HasOne(a => a.Kullanici)
                .WithOne()
                .HasForeignKey<Antrenor>(a => a.KullaniciId);
            
            // Program Katılım ilişkileri (n-n)
            modelBuilder.Entity<ProgramKatilim>()
                .HasOne(pk => pk.Uye)
                .WithMany(u => u.ProgramKatilimlari)
                .HasForeignKey(pk => pk.UyeId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ProgramKatilim>()
                .HasOne(pk => pk.SporProgrami)
                .WithMany(s => s.ProgramKatilimlari)
                .HasForeignKey(pk => pk.ProgramId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Ekipman Kullanım ilişkileri (n-n)
            modelBuilder.Entity<EkipmanKullanim>()
                .HasOne(ek => ek.SporProgrami)
                .WithMany(s => s.EkipmanKullanimlari)
                .HasForeignKey(ek => ek.ProgramId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<EkipmanKullanim>()
                .HasOne(ek => ek.Ekipman)
                .WithMany(e => e.EkipmanKullanimlari)
                .HasForeignKey(ek => ek.EkipmanId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Seed data
            SeedData(modelBuilder);
        }
        
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Admin kullanıcı ekleme - sabit bir tarih kullanıyoruz
            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici
                {
                    KullaniciId = 1,
                    KullaniciTipi = KullaniciTipi.Admin,
                    Ad = "Admin",
                    Soyad = "User",
                    Email = "admin@sportcenter.com",
                    Sifre = "Admin123!", // Gerçek uygulamada hash'lenmiş şifre kullanılmalı
                    KayitTarihi = new DateTime(2024, 3, 25) // Sabit bir tarih
                }
            );
        }
    }
} 