using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenter.Data;

namespace SportCenter.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Antrenör rolüne sahip olanlar için kontrol
        private bool IsTrainer()
        {
            return HttpContext.Session.GetInt32("UserType") == 2; // 2 = Antrenör
        }

        private async Task<int> GetTrainerIdAsync()
        {
            if (!IsTrainer())
                return 0;

            var userId = HttpContext.Session.GetInt32("UserId");
            var antrenor = await _context.Antrenorler
                .FirstOrDefaultAsync(a => a.KullaniciId == userId);

            return antrenor?.AntrenorId ?? 0;
        }

        public async Task<IActionResult> Index()
        {
            if (!IsTrainer())
                return RedirectToAction("Index", "Home");

            var antrenorId = await GetTrainerIdAsync();
            if (antrenorId == 0)
                return RedirectToAction("Index", "Home");

            // Antrenöre ait programları al
            var programs = await _context.SporProgramlari
                .Where(p => p.AntrenorId == antrenorId)
                .ToListAsync();

            // Antrenöre ait üye sayısını hesapla
            var memberCount = await _context.ProgramKatilimlari
                .Where(pk => pk.SporProgrami.AntrenorId == antrenorId)
                .Select(pk => pk.UyeId)
                .Distinct()
                .CountAsync();

            ViewBag.ProgramCount = programs.Count;
            ViewBag.MemberCount = memberCount;

            return View(programs);
        }

        public async Task<IActionResult> Programs()
        {
            if (!IsTrainer())
                return RedirectToAction("Index", "Home");

            var antrenorId = await GetTrainerIdAsync();
            if (antrenorId == 0)
                return RedirectToAction("Index", "Home");

            var programs = await _context.SporProgramlari
                .Where(p => p.AntrenorId == antrenorId)
                .ToListAsync();

            return View(programs);
        }

        public async Task<IActionResult> Members()
        {
            if (!IsTrainer())
                return RedirectToAction("Index", "Home");

            var antrenorId = await GetTrainerIdAsync();
            if (antrenorId == 0)
                return RedirectToAction("Index", "Home");

            // Antrenörün programlarına katılan üyeleri al
            var members = await _context.ProgramKatilimlari
                .Where(pk => pk.SporProgrami.AntrenorId == antrenorId)
                .Select(pk => new { Uye = pk.Uye, Kullanici = pk.Uye.Kullanici })
                .Distinct()
                .ToListAsync();

            return View(members);
        }

        public async Task<IActionResult> Equipment()
        {
            if (!IsTrainer())
                return RedirectToAction("Index", "Home");

            var equipment = await _context.Ekipmanlar.ToListAsync();
            return View(equipment);
        }

        public IActionResult Schedule()
        {
            if (!IsTrainer())
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
} 