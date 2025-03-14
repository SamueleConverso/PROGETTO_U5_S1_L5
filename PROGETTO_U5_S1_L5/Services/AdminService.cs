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

        public async Task<TotVerbaliViewModel> GetTotVerbaliAsync() {
            var result = new TotVerbaliViewModel();

            result.TotVerbali = await _context.Anagraficas.Select(a => new TotVerbaleModel {
                Nome = a.Nome,
                Cognome = a.Cognome,
                NumeroVerbali = a.Verbales.Count()
            }).ToListAsync();

            return result;
        }

        public async Task<TotPuntiDecurtatiViewModel> GetTotPuntiDecurtatiAsync() {
            var result = new TotPuntiDecurtatiViewModel();

            result.TotPuntiDecurtati = await _context.Anagraficas.Select(a => new TotPuntiDecurtatiModel {
                Nome = a.Nome,
                Cognome = a.Cognome,
                NumeroPuntiDecurtati = a.Verbales.Sum(v => v.DecurtamentoPunti)
            }).ToListAsync();

            return result;
        }

        public async Task<SuperDieciPuntiViewModel> GetSuperDieciPuntiAsync() {
            var result = new SuperDieciPuntiViewModel();

            result.SuperDieciPunti = await _context.Verbales.Where(v => v.DecurtamentoPunti >= 10).Include(v => v.IdanagraficaNavigation).Select(v => new SuperDieciPuntiModel {
                Nome = v.IdanagraficaNavigation.Nome,
                Cognome = v.IdanagraficaNavigation.Cognome,
                DataViolazione = v.DataViolazione,
                DecurtamentoPunti = v.DecurtamentoPunti,
                Importo = v.Importo
            }).ToListAsync();
            return result;
        }

        public async Task<VerbaliCostosiViewModel> GetVerbaliCostosiAsync() {
            var result = new VerbaliCostosiViewModel();

            result.VerbaliCostosi = await _context.Verbales.Where(v => v.Importo >= 400).Select(v => new VerbaliCostosiModel {
                DataViolazione = v.DataViolazione,
                IndirizzoViolazione = v.IndirizzoViolazione,
                NominativoAgente = v.NominativoAgente,
                DataTrascrizioneVerbale = v.DataTrascrizioneVerbale,
                Importo = v.Importo,
                DecurtamentoPunti = v.DecurtamentoPunti
            }).ToListAsync();

            return result;
        }
    }
}
