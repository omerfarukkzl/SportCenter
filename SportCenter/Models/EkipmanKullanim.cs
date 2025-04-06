using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportCenter.Models
{
    public class EkipmanKullanim
    {
        [Key]
        public int KullanimId { get; set; }
        
        [Required]
        public int ProgramId { get; set; }
        
        [Required]
        public int EkipmanId { get; set; }
        
        [Display(Name = "Kullanım Miktarı")]
        public int? KullanimMiktari { get; set; }
        
        [Display(Name = "Kullanım Tarihi")]
        [DataType(DataType.Date)]
        public DateTime KullanimTarihi { get; set; } = DateTime.Now;
        
        [Display(Name = "Notlar")]
        public string? Notlar { get; set; }
        
        // Navigation Properties
        [ForeignKey("ProgramId")]
        public SporProgrami? SporProgrami { get; set; }
        
        [ForeignKey("EkipmanId")]
        public Ekipman? Ekipman { get; set; }
    }
} 