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
using System.Windows.Shapes;

namespace picDb.Windows
{
    /// <summary>
    /// Interaktionslogik für PhotographerAdd.xaml
    /// </summary>
    public partial class PhotographerAdd : Window
    {
        private MainWindowViewModel _controller;
        public PhotographerAdd(MainWindowViewModel controller)
        {
            _controller = controller;
            InitializeComponent();
            this.DataContext = _controller;
        }

        private void AddPhotographer(object sender, RoutedEventArgs e)
        {
            var photographer = new PhotographerViewModel();

            photographer.FirstName = fn.Text;
            photographer.LastName = ln.Text;
            photographer.Notes = notes.Text;
            photographer.Birthday = bd.SelectedDate;

            _controller.savePhotographer(photographer);
        }
    }
}
