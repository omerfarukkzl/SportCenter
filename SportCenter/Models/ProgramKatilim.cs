using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportCenter.Models
{
    public class ProgramKatilim
    {
        [Key]
        public int KatilimId { get; set; }
        
        [Required]
        public int UyeId { get; set; }
        
        [Required]
        public int ProgramId { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Katılım Tarihi")]
        public DateTime KatilimTarihi { get; set; } = DateTime.Now;
        
        [Display(Name = "Katılım Durumu")]
        public bool KatilimDurumu { get; set; } = false;
        
        [Display(Name = "Notlar")]
        public string? Notlar { get; set; }
        
        // Navigation Properties
        [ForeignKey("UyeId")]
        public Uye? Uye { get; set; }
        
        [ForeignKey("ProgramId")]
        public SporProgrami? SporProgrami { get; set; }
    }
} 