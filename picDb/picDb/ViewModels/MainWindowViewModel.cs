using picDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace picDb.ViewModels
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private readonly BL _bl = new BL();
        private PictureViewModel _currentPicture;

        public PictureListViewModel PicList { get; set; } = new PictureListViewModel();
        public SearchViewModel Search { get; set; } = new SearchViewModel();
        public PhotographerListViewModel PhotographersList { get; set; } = new PhotographerListViewModel();

        public MainWindowViewModel()
        {
            CurrentPicture = PicList.CurrentPicture;
            
        }

        public void updatePic()
        {
            _bl.updatePicture(new PictureModel(CurrentPicture));
        }

        public void updatePhotographer()
        {
            _bl.updatePhotographer(new PhotographerModel(PhotographersList.CurrentPhotographer));
        }

        public void SavePicPhotographer()
        {
            ((PictureViewModel)CurrentPicture).Photographer = PhotographersList.CurrentPhotographer;
            _bl.updatePicturePhotographer(new PictureModel(CurrentPicture));
            
        }
        public PictureViewModel CurrentPicture
        {
            get => _currentPicture;
            set
            {
                if (_currentPicture != value && value != null)
                {
                    _currentPicture = new PictureViewModel(_bl.getPicture(value.ID));
                    ((PictureListViewModel)PicList).CurrentPicture = _currentPicture;                
                    OnPropertyChanged("CurrentPicture");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
