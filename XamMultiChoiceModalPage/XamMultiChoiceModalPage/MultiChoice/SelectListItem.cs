using System.ComponentModel;

namespace XamMultiChoiceModalPage
{
    public class SelectListItem<T> : INotifyPropertyChanged
    {
        public string Text { get; set; }

        public T Value { get; set; }

        bool isSelected = false;
        public bool Selected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
