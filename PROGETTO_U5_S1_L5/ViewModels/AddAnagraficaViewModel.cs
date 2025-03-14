using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROGETTO_U5_S1_L5.ViewModels {
    public class AddAnagraficaViewModel {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il nome è obbligatorio!")]
        [StringLength(200, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 1)]
        public string Nome {
            get; set;
        }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il cognome è obbligatorio!")]
        [StringLength(200, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 1)]
        public string Cognome {
            get; set;
        }

        [Display(Name = "Indirizzo")]
        [Required(ErrorMessage = "L'indirizzo è obbligatorio!")]
        [StringLength(200, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 1)]
        public string Indirizzo {
            get; set;
        }

        [Display(Name = "Città")]
        [Required(ErrorMessage = "La città è obbligatoria!")]
        [StringLength(200, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 1)]
        public string Citta {
            get; set;
        }

        [Display(Name = "Cap")]
        [Required(ErrorMessage = "Il Cap è obbligatorio!")]
        public int Cap {
            get; set;
        }

        [Display(Name = "Codice fiscale")]
        [Required(ErrorMessage = "Il codice fiscale è obbligatorio!")]
        [StringLength(17, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 16)]
        public string CodFisc {
            get; set;
        }

    }
}
