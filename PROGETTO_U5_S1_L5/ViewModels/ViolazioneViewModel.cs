using System.ComponentModel.DataAnnotations;
using PROGETTO_U5_S1_L5.Models;

namespace PROGETTO_U5_S1_L5.ViewModels {
    public class ViolazioneViewModel {

        public List<TipoViolazione> Violazioni {
            get; set;
        }

        public int IdViolazione {
            get; set;
        }
    }
}
