using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenter.Data;
using SportCenter.Models;
using SportCenter.ViewModels;

namespace SportCenter.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Kullanicilar
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Sifre == model.Sifre);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.KullaniciId);
                    HttpContext.Session.SetString("UserName", $"{user.Ad} {user.Soyad}");
                    HttpContext.Session.SetInt32("UserType", (int)user.KullaniciTipi);

                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Geçersiz email veya şifre");
            }

            return View(model);
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Email adresi daha önce kullanılmış mı kontrol et
                if (await _context.Kullanicilar.AnyAsync(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Bu email adresi zaten kullanılmakta");
                    return View(model);
                }

                // Yeni kullanıcı oluştur
                var kullanici = new Kullanici
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Email = model.Email,
                    Sifre = model.Sifre, // Gerçek uygulamada hash'lenmeli
                    KullaniciTipi = KullaniciTipi.Uye,
                    KayitTarihi = DateTime.Now
                };

                _context.Add(kullanici);
                await _context.SaveChangesAsync();

                // Kullanıcı kaydedildikten sonra üye bilgilerini ekle
                var uye = new Uye
                {
                    KullaniciId = kullanici.KullaniciId,
                    Telefon = model.Telefon,
                    Adres = model.Adres
                };

                _context.Add(uye);
                await _context.SaveChangesAsync();

                // Otomatik giriş yap
                HttpContext.Session.SetInt32("UserId", kullanici.KullaniciId);
                HttpContext.Session.SetString("UserName", $"{kullanici.Ad} {kullanici.Soyad}");
                HttpContext.Session.SetInt32("UserType", (int)kullanici.KullaniciTipi);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            // Session'ı temizle
            HttpContext.Session.Clear();
            
            return RedirectToAction("Index", "Home");
        }
    }
} 