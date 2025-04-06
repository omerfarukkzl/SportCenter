using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportCenter.Models
{
    public class SporProgrami
    {
        [Key]
        public int ProgramId { get; set; }
        
        [Required(ErrorMessage = "Program adı gereklidir")]
        [StringLength(100, ErrorMessage = "Program adı en fazla 100 karakter olabilir")]
        [Display(Name = "Program Adı")]
        public required string ProgramAdi { get; set; }
        
        [Required(ErrorMessage = "Başlangıç tarihi gereklidir")]
        [DataType(DataType.Date)]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime BaslangicTarihi { get; set; }
        
        [Required(ErrorMessage = "Bitiş tarihi gereklidir")]
        [DataType(DataType.Date)]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime BitisTarihi { get; set; }
        
        [Required(ErrorMessage = "Saat bilgisi gereklidir")]
        [Display(Name = "Program Saati")]
        [DataType(DataType.Time)]
        public TimeSpan ProgramSaati { get; set; }
        
        [Required(ErrorMessage = "Antrenör seçilmelidir")]
        [Display(Name = "Antrenör")]
        public int AntrenorId { get; set; }
        
        [ForeignKey("AntrenorId")]
        public Antrenor? Antrenor { get; set; }
        
        [Display(Name = "Program Açıklaması")]
        public string? Aciklama { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Kategori")]
        public string? Kategori { get; set; }
        
        [Display(Name = "Maksimum Katılımcı")]
        public int MaxKatilimci { get; set; } = 20;
        
        [Display(Name = "Katılımcı Sayısı")]
        public int KatilimciSayisi { get; set; } = 0;
        
        [StringLength(50)]
        [Display(Name = "Durum")]
        public string? Durum { get; set; }
        
        [Display(Name = "Aktif Mi?")]
        public bool AktifMi { get; set; } = true;
        
        [Display(Name = "Oluşturma Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual ICollection<ProgramKatilim>? ProgramKatilimlari { get; set; }
        public virtual ICollection<EkipmanKullanim>? EkipmanKullanimlari { get; set; }
        
        // Computed properties
        [NotMapped]
        public string Saat => ProgramSaati.ToString(@"hh\:mm");
    }
} 