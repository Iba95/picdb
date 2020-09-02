using picDb.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaktionslogik für PictureListComponent.xaml
    /// </summary>
    public partial class PictureListComponent : UserControl
    {
        private MainWindowViewModel _controller;
        public PictureListComponent()
        {
            _controller = new MainWindowViewModel();
            InitializeComponent();
        }

        private void PictureSelection_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (PictureSelection.SelectedItem is PictureViewModel)
            {
                if (((PictureViewModel)PictureSelection.SelectedItem) == null)
                {
                    MessageBox.Show("Picture is null");
                }
                else
                {
                    _controller.CurrentPicture = (PictureViewModel)PictureSelection.SelectedItem;
                }
            }
        }
    }
}
