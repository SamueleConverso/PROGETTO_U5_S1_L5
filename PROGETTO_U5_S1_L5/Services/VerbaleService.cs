using PROGETTO_U5_S1_L5.Models;
using PROGETTO_U5_S1_L5.Models;
using PROGETTO_U5_S1_L5.ViewModels;
using Microsoft.EntityFrameworkCore;
using PROGETTO_U5_S1_L5.Data;

namespace PROGETTO_U5_S1_L5.Services {
    public class VerbaleService {
        private readonly ApplicationDbContext _context;

        public VerbaleService(ApplicationDbContext context) {
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

        public async Task<VerbaleViewModel> GetAllVerbaliAsync() {
            try {
                var verbaliList = new VerbaleViewModel();

                verbaliList.Verbali = await _context.Verbales.ToListAsync();
                return verbaliList;
            } catch {
                return new VerbaleViewModel() { Verbali = new List<Verbale>() };
            }
        }

        public async Task<VerbaleViolazioneViewModel> GetViolazioniAsync(int idVerbale) {
            var violazioni = new VerbaleViolazioneViewModel();

            violazioni.VerbaliViolazioni = await _context.VerbaleViolaziones.Where(vv => vv.Idverbale == idVerbale).Include(vv => vv.IdviolazioneNavigation).ToListAsync();

            return violazioni;
        }

        public async Task<ViolazioneViewModel> GetAllViolazioniAsync() {
            try {
                var violazioni = new ViolazioneViewModel();

                violazioni.Violazioni = await _context.TipoViolaziones.ToListAsync();
                return violazioni;
            } catch {
                return new ViolazioneViewModel() { Violazioni = new List<TipoViolazione>() };
            }
        }

        public async Task<bool> ApplyViolazioneAsync(int idVerbale, int idViolazione) {
            var verbaleViolazione = new VerbaleViolazione() {
                Idverbale = idVerbale,
                Idviolazione = idViolazione
            };
            _context.VerbaleViolaziones.Add(verbaleViolazione);
            return await SaveAsync();
        }

        public async Task<bool> AddVerbaleAsync(AddVerbaleViewModel addVerbaleViewModel) {

            var verbale = new Verbale() {
                DataViolazione = addVerbaleViewModel.DataViolazione,
                IndirizzoViolazione = addVerbaleViewModel.IndirizzoViolazione,
                NominativoAgente = addVerbaleViewModel.NominativoAgente,
                DataTrascrizioneVerbale = addVerbaleViewModel.DataTrascrizioneVerbale,
                Importo = addVerbaleViewModel.Importo,
                DecurtamentoPunti = addVerbaleViewModel.DecurtamentoPunti,
                Idanagrafica = addVerbaleViewModel.Idanagrafica
            };

            _context.Verbales.Add(verbale);
            return await SaveAsync();
        }
    }
}
