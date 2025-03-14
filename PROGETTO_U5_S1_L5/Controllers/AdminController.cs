using Microsoft.AspNetCore.Mvc;
using PROGETTO_U5_S1_L5.Services;
using PROGETTO_U5_S1_L5.ViewModels;

namespace PROGETTO_U5_S1_L5.Controllers {
    public class AdminController : Controller {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService) {
            _adminService = adminService;
        }


        public async Task<IActionResult> Index() {
            var anagraficheList = await _adminService.GetAllAnagraficheAsync();

            return View(anagraficheList);
        }

        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewAnagrafica(AddAnagraficaViewModel addAnagraficaViewModel) {

            if (!ModelState.IsValid) {
                TempData["Error"] = "Errore durante l'aggiunta dell'anagrafica!";
                return RedirectToAction("Index");
            }

            var result = await _adminService.AddAnagraficaAsync(addAnagraficaViewModel);

            if (!result) {
                TempData["Error"] = "Errore durante l'aggiunta dell'anagrafica!";
            }

            return RedirectToAction("Index");
        }
    }
}
