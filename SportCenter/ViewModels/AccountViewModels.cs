using System.ComponentModel.DataAnnotations;

namespace SportCenter.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email alanı gereklidir")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Email")]
        public required string Email { get; set; }
        
        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public required string Sifre { get; set; }
    }
    
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [StringLength(50, ErrorMessage = "Ad alanı en fazla 50 karakter olabilir")]
        [Display(Name = "Ad")]
        public required string Ad { get; set; }
        
        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        [StringLength(50, ErrorMessage = "Soyad alanı en fazla 50 karakter olabilir")]
        [Display(Name = "Soyad")]
        public required string Soyad { get; set; }
        
        [Required(ErrorMessage = "Email alanı gereklidir")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Email")]
        public required string Email { get; set; }
        
        [Required(ErrorMessage = "Şifre alanı gereklidir")]
        [StringLength(100, ErrorMessage = "Şifre en az {2} karakter olmalıdır", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public required string Sifre { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Sifre", ErrorMessage = "Şifreler eşleşmiyor")]
        public required string SifreTekrar { get; set; }
        
        [Required(ErrorMessage = "Telefon numarası gereklidir")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public required string Telefon { get; set; }
        
        [Display(Name = "Adres")]
        public string? Adres { get; set; }
    }
} 