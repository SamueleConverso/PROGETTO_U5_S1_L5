using PROGETTO_U5_S1_L5.Models;
using PROGETTO_U5_S1_L5.Models;
using PROGETTO_U5_S1_L5.ViewModels;
using Microsoft.EntityFrameworkCore;
using PROGETTO_U5_S1_L5.Data;

namespace PROGETTO_U5_S1_L5.Services {
    public class AdminService {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context) {
            _context = context;
        }

        private async Task<bool> SaveAsync() {
            try {
                var rows = await _context.SaveChangesAsync();

                if (rows > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch {
                return false;
            }
        }

        public async Task<AnagraficaViewModel> GetAllAnagraficheAsync() {
            try {
                var anagraficheList = new AnagraficaViewModel();

                anagraficheList.Anagrafiche = await _context.Anagraficas.ToListAsync();
                return anagraficheList;
            } catch {
                return new AnagraficaViewModel() { Anagrafiche = new List<Anagrafica>() };
            }
        }

        public async Task<bool> AddAnagraficaAsync(AddAnagraficaViewModel addAnagraficaViewModel) {

            var anagrafica = new Anagrafica() {
                Nome = addAnagraficaViewModel.Nome,
                Cognome = addAnagraficaViewModel.Cognome,
                Indirizzo = addAnagraficaViewModel.Indirizzo,
                Citta = addAnagraficaViewModel.Citta,
                Cap = addAnagraficaViewModel.Cap,
                CodFisc = addAnagraficaViewModel.CodFisc
            };

            _context.Anagraficas.Add(anagrafica);
            return await SaveAsync();
        }

        public async Task<TotVerbaliViewModel> GetTorVerbaliAsync() {

            var totVerbali = new TotVerbaliViewModel();

            totVerbali.TotVerbali = await _context.Verbales.CountAsync();

            return totVerbali;
        }
    }
}
