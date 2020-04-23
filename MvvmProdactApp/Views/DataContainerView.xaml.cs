using MvvmProdactApp.ViewModels;
using System.Windows.Controls;

namespace MvvmProdactApp.Views
{
    /// <summary>
    /// Логика взаимодействия для DataContainerView.xaml
    /// </summary>
    public partial class DataContainerView : UserControl
    {
        public DataContainerView()
        {
            InitializeComponent();
            DataContext = new DataContainerVM();
        }
    }
}
