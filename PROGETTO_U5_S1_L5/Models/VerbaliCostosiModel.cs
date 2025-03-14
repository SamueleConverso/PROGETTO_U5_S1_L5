using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROGETTO_U5_S1_L5.Models {
    public class VerbaliCostosiModel {
        public DateOnly DataViolazione {
            get; set;
        }

        public string IndirizzoViolazione {
            get; set;
        }

        public string NominativoAgente {
            get; set;
        }

        public DateOnly DataTrascrizioneVerbale {
            get; set;
        }

        public decimal Importo {
            get; set;
        }

        public int DecurtamentoPunti {
            get; set;
        }
    }
}
