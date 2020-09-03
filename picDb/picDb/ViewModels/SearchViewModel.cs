using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace picDb.ViewModels
{
    public class SearchViewModel: INotifyPropertyChanged
    {
        private string _term;
        public string Term
        {
            get => _term;
            set
            {
                if (_term != value)
                {
                    _term = value;
                    OnPropertyChanged("Term");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
