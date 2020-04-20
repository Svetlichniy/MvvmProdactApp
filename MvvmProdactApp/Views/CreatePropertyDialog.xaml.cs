using MvvmProdactApp.ViewModels;
using System.Windows;

namespace MvvmProdactApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CreatePropertyDialog.xaml
    /// </summary>
    public partial class CreatePropertyDialog : Window
    {
        public CreatePropertyDialog()
        {
            InitializeComponent();
            DataContext = new CreatePropertyDialogVM();
        }
    }
}
