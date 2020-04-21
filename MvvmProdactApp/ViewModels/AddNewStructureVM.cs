using MvvmProdactApp.Models;
using MvvmProdactApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MvvmProdactApp.ViewModels
{
    public class AddNewStructureVM : NotifyInterface
    {
        public ObservableCollection<ProdactObject> SelectedProdacts { get; set; }
        public ObservableCollection<ProdactObject> AllProdacts { get; set; }

        public AddNewStructureVM()
        {
            AllProdacts = new ObservableCollection<ProdactObject>();
            AppService.StaticStoredObjs.ProdactObjects
                .ToList()
                .ForEach(e => AllProdacts.Add(e));

            SelectedProdacts = new ObservableCollection<ProdactObject>();
        }

        public ICommand AddSelectedItems
        {
            get { return new ParamCommand(Items => AddNewStrucutries(Items)); }
        }

        private void AddNewStrucutries(object items)
        {
            if (items == null)
                return;

            foreach (var item in (IEnumerable)items)
                SelectedProdacts.Add((ProdactObject)item);
        }

        public ICommand RemoveFromResult
        {
            get { return new ParamCommand(Items => RemoveSelectedItems(Items)); }
        }

        private void RemoveSelectedItems(object items)
        {
            if (items == null)
                return;

            var ItemsToDelete = new ArrayList();
            foreach (var item in (IEnumerable)items)
                ItemsToDelete.Add(item);

            foreach(var item in ItemsToDelete)
                SelectedProdacts.Remove((ProdactObject)item);
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
