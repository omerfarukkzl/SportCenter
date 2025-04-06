using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenter.Data;

namespace SportCenter.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Üye rolüne sahip olanlar için kontrol
        private bool IsMember()
        {
            return HttpContext.Session.GetInt32("UserType") == 3; // 3 = Üye
        }

        private async Task<int> GetMemberIdAsync()
        {
            if (!IsMember())
                return 0;

            var userId = HttpContext.Session.GetInt32("UserId");
            var uye = await _context.Uyeler
                .FirstOrDefaultAsync(u => u.KullaniciId == userId);

            return uye?.UyeId ?? 0;
        }

        public async Task<IActionResult> Index()
        {
            if (!IsMember())
                return RedirectToAction("Index", "Home");

            var uyeId = await GetMemberIdAsync();
            if (uyeId == 0)
                return RedirectToAction("Index", "Home");

            // Üyenin katıldığı programları al
            var programs = await _context.ProgramKatilimlari
                .Where(pk => pk.UyeId == uyeId)
                .Select(pk => pk.SporProgrami)
                .ToListAsync();

            ViewBag.ProgramCount = programs.Count;

            return View(programs);
        }

        public async Task<IActionResult> Programs()
        {
            if (!IsMember())
                return RedirectToAction("Index", "Home");

            var programs = await _context.SporProgramlari
                .Include(p => p.Antrenor)
                .ThenInclude(a => a.Kullanici)
                .ToListAsync();

            return View(programs);
        }

        public async Task<IActionResult> MyPrograms()
        {
            if (!IsMember())
                return RedirectToAction("Index", "Home");

            var uyeId = await GetMemberIdAsync();
            if (uyeId == 0)
                return RedirectToAction("Index", "Home");

            var myPrograms = await _context.ProgramKatilimlari
                .Where(pk => pk.UyeId == uyeId)
                .Include(pk => pk.SporProgrami)
                .ThenInclude(sp => sp.Antrenor)
                .ThenInclude(a => a.Kullanici)
                .ToListAsync();

            return View(myPrograms);
        }

        public async Task<IActionResult> Trainers()
        {
            if (!IsMember())
                return RedirectToAction("Index", "Home");

            var trainers = await _context.Antrenorler
                .Include(a => a.Kullanici)
                .ToListAsync();

            return View(trainers);
        }

        public async Task<IActionResult> Equipment()
        {
            if (!IsMember())
                return RedirectToAction("Index", "Home");

            var equipment = await _context.Ekipmanlar.ToListAsync();
            return View(equipment);
        }

        public IActionResult Schedule()
        {
            if (!IsMember())
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
} 