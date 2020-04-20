using Microsoft.Win32;
using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace MvvmProdactApp.ViewModels
{
    public class CreatePropertyDialogVM : NotifyInterface
    {
        private string name;
        private BitmapImage propImage;

        public CreatePropertyDialogVM()
        {

        }

        public  string Name 
        {
            get { return name; }    
            set
            {
                name = value;
                RaisePropertyChangedEvent("Name");
            }
        }

        public BitmapImage PropImage
        {
            get { return propImage; }
            set
            {
                propImage = value;
                RaisePropertyChangedEvent("PropImage");
            }
        }

        public ICommand SetImage
        {
            get { return new ParamCommand(obj => _SetImage()); }
        }

        private void _SetImage()
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@openDialog.FileName);
                bitmap.EndInit();
                bitmap.Freeze();

                PropImage = bitmap;
            }
        }

        public ICommand SetResult
        {
            get { return new ParamCommand(DialogWindow => CloseDialog(DialogWindow)); }
        }
        private void CloseDialog(object DialogWindow)
        {
            var Dialog = DialogWindow as Window;
            Dialog.DialogResult = true;
            Dialog.Close();
        }
    }
}
