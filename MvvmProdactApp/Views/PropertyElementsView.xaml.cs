using MvvmProdactApp.ViewModels;
using System.Windows.Controls;

namespace MvvmProdactApp.Views
{
    /// <summary>
    /// Логика взаимодействия для PropertyElementsView.xaml
    /// </summary>
    public partial class PropertyElementsView : UserControl
    {
        public PropertyElementsView()
        {
            InitializeComponent();
            DataContext = new PropertyElementsVM();
        }
    }
}
