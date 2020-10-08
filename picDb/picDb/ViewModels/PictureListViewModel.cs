using picDb.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace picDb.ViewModels
{
    public class PictureListViewModel: INotifyPropertyChanged
    {
        private BL _bl;
        private PictureViewModel _currentPicture;
        private ObservableCollection<PictureViewModel> _pics = new ObservableCollection<PictureViewModel>();

        public ObservableCollection<PictureViewModel> _backupList;

        public PictureListViewModel()
        {
            _bl = new BL();
            getPics(null);
        }
        public PictureViewModel CurrentPicture
        {
            get => _currentPicture;
            set
            {
                if (_currentPicture != value)
                {
                    _currentPicture = value;
                    OnPropertyChanged(nameof(CurrentPicture));
                }
            }
        }
        public IEnumerable<PictureViewModel> Pics
        {
            get => _pics;
            set
            {
                _pics = (ObservableCollection<PictureViewModel>)value;
                OnPropertyChanged("Pics");
            }
        }
        public void getPics(string term)
        {
            _bl.sync();
            _pics.Clear();
            var pics = new List<PictureModel>();
            if (!string.IsNullOrEmpty(term))
                 pics = _bl.getPictures(term).ToList();
            else
                 pics = _bl.getPictures().ToList(); 
            foreach(PictureModel pic in pics)
            {
                _pics.Add(new PictureViewModel((PictureModel)pic));
            }
            int firstModelID = _pics.First().ID;
            CurrentPicture = new PictureViewModel(_bl.getPicture(firstModelID));
        }
        //public void ResetList()
        //{
        //    _pics = new ObservableCollection<PictureViewModel>(_backupList);
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
