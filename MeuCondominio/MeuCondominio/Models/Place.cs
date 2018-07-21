namespace MeuCondominio.Models
{
    public class Place : MvvmHelpers.ObservableObject
    {
        public string Block { get; set; }
        public string Number { get; set; }

        private bool _IsSelected;
        public bool IsSelected {
            get
            {
                return _IsSelected;
            }
            set
            {
                SetProperty(ref _IsSelected, value);
            }
        }
    }
}
