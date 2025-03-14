namespace PROGETTO_U5_S1_L5.ViewModels {
    public class ErrorViewModel {
        public string? RequestId {
            get; set;
        }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
