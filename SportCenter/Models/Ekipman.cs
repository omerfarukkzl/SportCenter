using System.ComponentModel.DataAnnotations;

namespace SportCenter.Models
{
    public enum EkipmanDurumu
    {
        Kullanilabilir,
        Bakimda,
        ArizaVar
    }
    
    public class Ekipman
    {
        [Key]
        public int EkipmanId { get; set; }
        
        [Required(ErrorMessage = "Ekipman adı gereklidir")]
        [StringLength(100, ErrorMessage = "Ekipman adı en fazla 100 karakter olabilir")]
        [Display(Name = "Ekipman Adı")]
        public required string EkipmanAdi { get; set; }
        
        [Display(Name = "Ekipman Durumu")]
        public EkipmanDurumu Durum { get; set; } = EkipmanDurumu.Kullanilabilir;
        
        [Required(ErrorMessage = "Konum bilgisi gereklidir")]
        [StringLength(100, ErrorMessage = "Konum bilgisi en fazla 100 karakter olabilir")]
        [Display(Name = "Konum")]
        public required string Konum { get; set; }
        
        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }
        
        [Display(Name = "Alım Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? AlimTarihi { get; set; }
        
        [Display(Name = "Son Bakım Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? SonBakimTarihi { get; set; }
        
        // Navigation Property
        public virtual ICollection<EkipmanKullanim>? EkipmanKullanimlari { get; set; }
    }
} 