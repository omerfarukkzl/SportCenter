using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportCenter.Models
{
    public enum KullaniciTipi
    {
        Uye = 0,
        Admin = 1,
        Antrenor = 2
    }

    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Sifre { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string Ad { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string Soyad { get; set; } = string.Empty;
        
        [Required]
        public KullaniciTipi KullaniciTipi { get; set; }
        
        [Required]
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        
        [Required]
        public bool Aktif { get; set; } = true;
        
        // Navigation properties
        public virtual Antrenor? Antrenor { get; set; }
        public virtual Uye? Uye { get; set; }
    }
} 