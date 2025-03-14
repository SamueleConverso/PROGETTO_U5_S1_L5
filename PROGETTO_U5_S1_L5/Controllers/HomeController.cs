using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROGETTO_U5_S1_L5.Data;
using PROGETTO_U5_S1_L5.Models;
using PROGETTO_U5_S1_L5.Services;
using PROGETTO_U5_S1_L5.ViewModels;

namespace PROGETTO_U5_S1_L5.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        private readonly AdminService _adminService;

        public HomeController(ILogger<HomeController> logger, AdminService adminService) {
            _logger = logger;
            _adminService = adminService;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TotVerbali() {
            return View();
        }

        public async Task<IActionResult> CalcTotVerbali() {
            return View();
        }
    }
}
