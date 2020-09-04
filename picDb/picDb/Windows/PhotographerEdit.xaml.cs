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
    /// Interaktionslogik für PhotographerEdit.xaml
    /// </summary>
    public partial class PhotographerEdit : Window
    {
        private MainWindowViewModel _controller;
        public PhotographerEdit(MainWindowViewModel controller)
        {
            _controller = controller;
            InitializeComponent();
            _controller = controller;
        }
    }
}
