using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportCenter.Models
{
    public class Antrenor
    {
        [Key]
        public int AntrenorId { get; set; }
        
        [ForeignKey("Kullanici")]
        public int? KullaniciId { get; set; }
        public virtual Kullanici? Kullanici { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Uzmanlık Alanı")]
        public string UzmanlikAlani { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Deneyim (Yıl)")]
        public int Deneyim { get; set; }
        
        [Required]
        [StringLength(100)]
        [Display(Name = "İletişim Bilgisi")]
        public string IletisimBilgisi { get; set; } = string.Empty;
        
        [StringLength(1000)]
        [Display(Name = "Özgeçmiş")]
        public string? Ozgecmis { get; set; }
        
        [Required]
        [Display(Name = "Aktif Mi")]
        public bool Aktif { get; set; } = true;
        
        // Navigation properties
        public virtual ICollection<SporProgrami>? SporProgramlari { get; set; }
        
        // Computed properties
        [NotMapped]
        public string AdSoyad => Kullanici != null ? $"{Kullanici.Ad} {Kullanici.Soyad}" : string.Empty;
    }
} 