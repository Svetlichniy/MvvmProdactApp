using MvvmProdactApp.ViewModels;
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

namespace MvvmProdactApp.Views
{
    /// <summary>
    /// Логика взаимодействия для TreeNavigationView.xaml
    /// </summary>
    public partial class TreeNavigationView : UserControl
    {
        public TreeNavigationView()
        {
            InitializeComponent();
            DataContext = new TreeNavigationVM();
        }
    }
}
