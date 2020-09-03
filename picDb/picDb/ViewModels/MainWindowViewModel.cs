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
        public PhotographerListViewModel PhotographerList { get; set; } = new PhotographerListViewModel();

        public MainWindowViewModel()
        {
            CurrentPicture = PicList.CurrentPicture;
        }

        public void updatePic()
        {
            _bl.updatePicture(new PictureModel(CurrentPicture));
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
                    OnPropertyChanged(nameof(CurrentPicture));
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
