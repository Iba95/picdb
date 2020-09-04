using picDb.ViewModels;
using picDb.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace picDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _controller;
        public MainWindow()
        {
            _controller = new MainWindowViewModel();
            InitializeComponent();
            this.DataContext = _controller;
        }

        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            // your event handler here
            e.Handled = true;

            ObservableCollection<PictureViewModel> filteredList = new ObservableCollection<PictureViewModel>();
            //_controller.Search.Term = Searchbox.Text;
            _controller.PicList.getPics(_controller.Search.Term);
        }

        private void btnSavePicPhotographer(object sender, RoutedEventArgs e)
        {
            //var PhotographerViewModel = (PhotographerViewModel)PhotographersListBox.SelectedItem;
            var photographer = _controller.PhotographersList.CurrentPhotographer;
            _controller.SavePicPhotographer(photographer);
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            _controller.updatePic();
        }

        private void editPhotographers(object sender, RoutedEventArgs e)
        {
            var epWindow = new PhotographerEdit(_controller);

            epWindow.Show();
        }
        private void addPhotographer(object sender, RoutedEventArgs e)
        {
            //var epWindow = new PhotographerEdit(_controller);

            //epWindow.Show();
        }

        private void helpClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bin selber Lost");
        }
    }
}
