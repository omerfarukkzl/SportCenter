using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenter.Data;
using SportCenter.Models;
using SportCenter.ViewModels;
using System.Data;

namespace SportCenter.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard
        public IActionResult Index()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            // Dashboard istatistiklerini al
            var viewModel = new AdminDashboardViewModel
            {
                UyeSayisi = _context.Uyeler.Count(),
                AntrenorSayisi = _context.Antrenorler.Count(),
                ProgramSayisi = _context.SporProgramlari.Count(),
                EkipmanSayisi = _context.Ekipmanlar.Count(),
                AktifProgramSayisi = _context.SporProgramlari.Count(p => p.AktifMi),
                BakimdakiEkipmanSayisi = _context.Ekipmanlar.Count(e => e.Durum == EkipmanDurumu.Bakimda)
            };

            return View(viewModel);
        }

        // Kullanıcı Yönetimi
        public async Task<IActionResult> Users()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var kullanicilar = await _context.Kullanicilar
                .Where(k => k.KullaniciTipi == KullaniciTipi.Uye)
                .OrderByDescending(k => k.KayitTarihi)
                .ToListAsync();

            return View(kullanicilar);
        }

        public IActionResult AddUser()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(RegisterViewModel model)
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

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

                return RedirectToAction(nameof(Users));
            }

            return View(model);
        }

        public async Task<IActionResult> EditUser(int id)
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }

            var uye = await _context.Uyeler.FirstOrDefaultAsync(u => u.KullaniciId == id);
            if (uye == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                KullaniciId = kullanici.KullaniciId,
                Ad = kullanici.Ad,
                Soyad = kullanici.Soyad,
                Email = kullanici.Email,
                Telefon = uye.Telefon,
                Adres = uye.Adres
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            if (ModelState.IsValid)
            {
                var kullanici = await _context.Kullanicilar.FindAsync(model.KullaniciId);
                if (kullanici == null)
                {
                    return NotFound();
                }

                var uye = await _context.Uyeler.FirstOrDefaultAsync(u => u.KullaniciId == model.KullaniciId);
                if (uye == null)
                {
                    return NotFound();
                }

                // Kullanıcı bilgilerini güncelle
                kullanici.Ad = model.Ad;
                kullanici.Soyad = model.Soyad;
                kullanici.Email = model.Email;

                // Üye bilgilerini güncelle
                uye.Telefon = model.Telefon;
                uye.Adres = model.Adres;

                _context.Update(kullanici);
                _context.Update(uye);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Users));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }

            var uye = await _context.Uyeler.FirstOrDefaultAsync(u => u.KullaniciId == id);
            if (uye != null)
            {
                _context.Uyeler.Remove(uye);
            }

            _context.Kullanicilar.Remove(kullanici);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Users));
        }

        // Antrenör Yönetimi
        public async Task<IActionResult> Trainers()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var antrenorler = await _context.Antrenorler
                .Include(a => a.Kullanici)
                .ToListAsync();

            return View(antrenorler);
        }

        public IActionResult AddTrainer()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTrainer(TrainerViewModel model)
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

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
                    KullaniciTipi = KullaniciTipi.Antrenor,
                    KayitTarihi = DateTime.Now
                };

                _context.Add(kullanici);
                await _context.SaveChangesAsync();

                // Kullanıcı kaydedildikten sonra antrenör bilgilerini ekle
                var antrenor = new Antrenor
                {
                    KullaniciId = kullanici.KullaniciId,
                    UzmanlikAlani = model.UzmanlikAlani,
                    Deneyim = model.Deneyim,
                    IletisimBilgisi = model.IletisimBilgisi
                };

                _context.Add(antrenor);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Trainers));
            }

            return View(model);
        }

        // Program Yönetimi
        public async Task<IActionResult> Programs()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var programlar = await _context.SporProgramlari
                .Include(p => p.Antrenor)
                .ThenInclude(a => a.Kullanici)
                .OrderByDescending(p => p.BaslangicTarihi)
                .ToListAsync();

            return View(programlar);
        }

        public async Task<IActionResult> AddProgram()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            // Antrenör listesini alıp ViewBag ile taşı
            ViewBag.Antrenorler = await _context.Antrenorler
                .Include(a => a.Kullanici)
                .Select(a => new
                {
                    Id = a.AntrenorId,
                    AdSoyad = a.Kullanici.Ad + " " + a.Kullanici.Soyad + " (" + a.UzmanlikAlani + ")"
                })
                .ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProgram(SporProgrami model)
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Programs));
            }

            // Hata durumunda antrenör listesini tekrar yükle
            ViewBag.Antrenorler = await _context.Antrenorler
                .Include(a => a.Kullanici)
                .Select(a => new
                {
                    Id = a.AntrenorId,
                    AdSoyad = a.Kullanici.Ad + " " + a.Kullanici.Soyad + " (" + a.UzmanlikAlani + ")"
                })
                .ToListAsync();

            return View(model);
        }

        // Ekipman Yönetimi
        public async Task<IActionResult> Equipment()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var ekipmanlar = await _context.Ekipmanlar.ToListAsync();
            return View(ekipmanlar);
        }

        public IActionResult AddEquipment()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEquipment(Ekipman model)
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Equipment));
            }

            return View(model);
        }

        // Raporlar
        public async Task<IActionResult> Reports()
        {
            // Admin erişim kontrolü
            if (HttpContext.Session.GetInt32("UserType") != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var raporViewModel = new ReportsViewModel
            {
                EnCokKatilanUyeler = await _context.ProgramKatilimlari
                    .GroupBy(k => k.UyeId)
                    .Select(g => new EnCokKatilanUye
                    {
                        UyeId = g.Key,
                        KatilimSayisi = g.Count(),
                        UyeAdi = _context.Uyeler
                            .Where(u => u.UyeId == g.Key)
                            .Join(_context.Kullanicilar, u => u.KullaniciId, k => k.KullaniciId, (u, k) => k.Ad + " " + k.Soyad)
                            .FirstOrDefault() ?? "Bilinmeyen Üye"
                    })
                    .OrderByDescending(u => u.KatilimSayisi)
                    .Take(5)
                    .ToListAsync(),

                EnPopulerProgramlar = await _context.ProgramKatilimlari
                    .GroupBy(k => k.ProgramId)
                    .Select(g => new EnPopulerProgram
                    {
                        ProgramId = g.Key,
                        KatilimSayisi = g.Count(),
                        ProgramAdi = _context.SporProgramlari
                            .Where(p => p.ProgramId == g.Key)
                            .Select(p => p.ProgramAdi)
                            .FirstOrDefault() ?? "Bilinmeyen Program"
                    })
                    .OrderByDescending(p => p.KatilimSayisi)
                    .Take(5)
                    .ToListAsync(),

                AntrenorIstatistikleri = await _context.SporProgramlari
                    .GroupBy(p => p.AntrenorId)
                    .Select(g => new AntrenorIstatistik
                    {
                        AntrenorId = g.Key,
                        ProgramSayisi = g.Count(),
                        AntrenorAdi = _context.Antrenorler
                            .Where(a => a.AntrenorId == g.Key)
                            .Join(_context.Kullanicilar, a => a.KullaniciId, k => k.KullaniciId, (a, k) => k.Ad + " " + k.Soyad)
                            .FirstOrDefault() ?? "Bilinmeyen Antrenör"
                    })
                    .OrderByDescending(a => a.ProgramSayisi)
                    .ToListAsync()
            };

            return View(raporViewModel);
        }

        // Profil
        public async Task<IActionResult> Profile()
        {
            // Kullanıcı ID'sini al
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var kullanici = await _context.Kullanicilar.FindAsync(userId);
            if (kullanici == null)
            {
                return NotFound();
            }

            var model = new ProfileViewModel
            {
                KullaniciId = kullanici.KullaniciId,
                Ad = kullanici.Ad,
                Soyad = kullanici.Soyad,
                Email = kullanici.Email
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var kullanici = await _context.Kullanicilar.FindAsync(model.KullaniciId);
                if (kullanici == null)
                {
                    return NotFound();
                }

                // Kullanıcı bilgilerini güncelle
                kullanici.Ad = model.Ad;
                kullanici.Soyad = model.Soyad;
                kullanici.Email = model.Email;

                // Şifre değişikliği varsa
                if (!string.IsNullOrEmpty(model.YeniSifre))
                {
                    kullanici.Sifre = model.YeniSifre; // Gerçek uygulamada hash'lenmeli
                }

                _context.Update(kullanici);
                await _context.SaveChangesAsync();

                // Session değerlerini güncelle
                HttpContext.Session.SetString("UserName", $"{kullanici.Ad} {kullanici.Soyad}");

                ViewBag.Message = "Profiliniz başarıyla güncellendi.";
            }

            return View(model);
        }
    }
} 