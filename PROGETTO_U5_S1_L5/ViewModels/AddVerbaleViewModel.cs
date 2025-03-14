using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROGETTO_U5_S1_L5.ViewModels {
    public class AddVerbaleViewModel {
        [Display(Name = "Data violazione")]
        [Required(ErrorMessage = "La data violazione è obbligatoria!")]
        public DateOnly DataViolazione {
            get; set;
        }

        [Display(Name = "Indirizzo violazione")]
        [Required(ErrorMessage = "L'indirizzo violazione è obbligatorio!")]
        [StringLength(200, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 1)]
        public string IndirizzoViolazione { get; set; } = null!;

        [Display(Name = "Nominativo agente")]
        [Required(ErrorMessage = "Il nominativo agente è obbligatorio!")]
        [StringLength(200, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 1)]
        public string NominativoAgente { get; set; } = null!;

        [Display(Name = "Data trascrizione verbale")]
        [Required(ErrorMessage = "La data trascrizione è obbligatoria!")]
        public DateOnly DataTrascrizioneVerbale {
            get; set;
        }

        [Display(Name = "Importo")]
        [Required(ErrorMessage = "L'importo è obbligatorio!")]
        public decimal Importo {
            get; set;
        }

        [Display(Name = "Decurtamento punti")]
        [Required(ErrorMessage = "Il decurtamento punti è obbligatorio!")]
        public int DecurtamentoPunti {
            get; set;
        }

        [Display(Name = "Id anagrafica")]
        [Required(ErrorMessage = "L'id anagrafica è obbligatorio!")]
        public int Idanagrafica {
            get; set;
        }
    }
}
