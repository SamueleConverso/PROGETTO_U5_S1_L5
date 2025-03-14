namespace PROGETTO_U5_S1_L5.Models {
    public class SuperDieciPuntiModel {
        public string Nome {
            get; set;
        }

        public string Cognome {
            get; set;
        }
        public DateOnly DataViolazione {
            get; set;
        }

        public int DecurtamentoPunti {
            get; set;
        }

        public decimal Importo {
            get; set;
        }
    }
}
