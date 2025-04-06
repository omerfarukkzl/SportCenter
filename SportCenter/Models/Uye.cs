using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportCenter.Models
{
    public class Uye
    {
        [Key]
        public int UyeId { get; set; }
        
        [Required]
        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Required(ErrorMessage = "Telefon numarası gereklidir")]
        [StringLength(20)]
        public string Telefon { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? Adres { get; set; }

        [Required]
        public bool Aktif { get; set; } = true;
        
        // Navigation properties
        public virtual Kullanici? Kullanici { get; set; }
        public virtual ICollection<ProgramKatilim>? ProgramKatilimlari { get; set; } = new List<ProgramKatilim>();
    }
} 