using System;
using System.ComponentModel.DataAnnotations;

namespace SportCenter.ViewModels
{
    public class EditUserViewModel
    {
        public int KullaniciId { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }

        [Display(Name = "Adres")]
        public string Adres { get; set; }
    }
} 