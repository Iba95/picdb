﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace picDb.ViewModels
{
    public class PhotographerListViewModel : INotifyPropertyChanged
    {
        private IEnumerable<PhotographerViewModel> _photographers;
        private PhotographerViewModel _currentPhotographer;
        public IEnumerable<PhotographerViewModel> Photographers
        {
            get => _photographers;
            private set
            {
                _photographers = value;
                OnPropertyChanged("Photographers");
            }
        }
        public PhotographerViewModel CurrentPhotographer
        {
            get => _currentPhotographer;
            set
            {
                _currentPhotographer = value;
                OnPropertyChanged("CurrentPhotographer");
            }
        }
        public PhotographerListViewModel()
        {
            SynchronizePhotographers();
        }
        public void SynchronizePhotographers()
        {
            var bl = new BL();
            var photographers = bl.getPhotographers();
            var pvm = new ObservableCollection<PhotographerViewModel>();
            foreach (var photographer in photographers)
            {
                pvm.Add(new PhotographerViewModel(photographer));
            }
            Photographers = pvm;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
