using MvvmProdactApp.ViewModels;
using System.Windows;

namespace MvvmProdactApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddNewStructureDialog.xaml
    /// </summary>
    public partial class AddNewStructureDialog : Window
    {
        public AddNewStructureDialog()
        {
            InitializeComponent();
            DataContext = new AddNewStructureVM();
        }
    }
}
