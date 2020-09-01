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
        private string _title;
        private string _testImage;


        public MainWindowViewModel()
        {
            Title = "PicDB";
            string Folder = @"C:\Users\islam\Documents\Arbeit\FH\4 SEM\SWE 2\pics\";

            TestImage = Folder+_bl.getPicture(3).FileName;
            _bl.getPictures();
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
               _title = value;                
            }
        }

        public string TestImage
        {
            get
            {
                return _testImage;
            }
            set
            {
                _testImage = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
