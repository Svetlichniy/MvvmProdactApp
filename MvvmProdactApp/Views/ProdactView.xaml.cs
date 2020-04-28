using MvvmProdactApp.ViewModels;
using System.Windows.Controls;

namespace MvvmProdactApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ProdactView.xaml
    /// </summary>
    public partial class ProdactView : UserControl
    {
        public ProdactView()
        {
            InitializeComponent();
            DataContext = new ProdactVM();
        }
    }
}
