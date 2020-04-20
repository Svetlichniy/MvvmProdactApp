using MvvmProdactApp.ViewModels;
using System.Windows;

namespace MvvmProdactApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateDialog.xaml
    /// </summary>
    public partial class CreateDialog : Window
    {
        public CreateDialog()
        {
            InitializeComponent();
            DataContext = new CreateDialogVM();
        }
    }
}
