using MvvmProdactApp.ViewModels;
using System.Windows.Controls;

namespace MvvmProdactApp.Views
{
    /// <summary>
    /// Логика взаимодействия для PropertyView.xaml
    /// </summary>
    public partial class PropertyView : UserControl
    {
        public PropertyView()
        {
            InitializeComponent();
            DataContext = new PropertyVM();
        }
    }
}
