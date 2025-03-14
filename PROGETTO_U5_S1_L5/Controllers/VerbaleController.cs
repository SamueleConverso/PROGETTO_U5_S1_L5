using Microsoft.AspNetCore.Mvc;
using PROGETTO_U5_S1_L5.Models;
using PROGETTO_U5_S1_L5.Services;
using PROGETTO_U5_S1_L5.ViewModels;

namespace PROGETTO_U5_S1_L5.Controllers {
    public class VerbaleController : Controller {
        private readonly VerbaleService _verbaleService;
        private readonly AdminService _adminService;

        public VerbaleController(VerbaleService verbaleService, AdminService adminService) {
            _verbaleService = verbaleService;
            _adminService = adminService;
        }


        public async Task<IActionResult> Index() {
            var verbaliList = await _verbaleService.GetAllVerbaliAsync();

            return View(verbaliList);
        }

        [HttpGet("violazioni/{idVerbale:int}")]
        public async Task<IActionResult> Violazioni(int idVerbale) {

            var violazioni = await _verbaleService.GetViolazioniAsync(idVerbale);
            ViewData["IdVerbale"] = idVerbale;
            return View(violazioni);
        }

        public async Task<IActionResult> AddViolazione(int idVerbale) {
            var violazioni = await _verbaleService.GetAllViolazioniAsync();
            ViewData["IdVerbale"] = idVerbale;
            return View(violazioni);
        }

        [HttpPost("apply-violazione/{idVerbale:int}")]
        public async Task<IActionResult> ApplyViolazione(int idVerbale, ViolazioneViewModel violazioneViewModel) {

            int idViolazione = violazioneViewModel.IdViolazione;
            int idVerbalePreso = idVerbale;

            var result = await _verbaleService.ApplyViolazioneAsync(idVerbalePreso, idViolazione);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddVerbale() {
            ViewBag.Anagrafiche = await _adminService.GetAllAnagraficheAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewVerbale(AddVerbaleViewModel addVerbaleViewModel) {
            if (!ModelState.IsValid) {
                TempData["Error"] = "Errore durante l'aggiunta del verbale!";
                return RedirectToAction("Index");
            }

            var result = await _verbaleService.AddVerbaleAsync(addVerbaleViewModel);

            if (!result) {
                TempData["Error"] = "Errore durante l'aggiunta del verbale!";
            }

            return RedirectToAction("Index");
        }
    }
}
