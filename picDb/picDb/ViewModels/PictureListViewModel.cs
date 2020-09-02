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
            getPics();
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
        public void getPics()
        {
            _bl.sync();
            //var pictures = bl.getPictures();
            //CurrentPicture = null;
            //_pics.Clear();
            //foreach (PictureModel model in pictures)
            //{
            //    _pics.Add(new PictureViewModel((PictureModel)model));
            //}
            //_backupList = new ObservableCollection<PictureViewModel>(_pics);

            //int firstModelID = _pics.First().ID;
            //CurrentPicture = new PictureViewModel(bl.getPicture(firstModelID));
            var pics = _bl.getPictures();
            foreach(PictureModel pic in pics)
            {
                _pics.Add(new PictureViewModel((PictureModel)pic));
            }
            int firstModelID = _pics.First().ID;
            CurrentPicture = new PictureViewModel(_bl.getPicture(firstModelID));

        }
        public void ResetList()
        {
            _pics = new ObservableCollection<PictureViewModel>(_backupList);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
