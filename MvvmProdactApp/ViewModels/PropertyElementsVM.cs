using MvvmProdactApp.Models.ObjProppsClasses;
using MvvmProdactApp.Services;
using MvvmProdactApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MvvmProdactApp.ViewModels
{
    public class PropertyElementsVM : NotifyInterface
    {
        public ObservableCollection<PropertyObj> ObjectPropperties { get; set; }

        public PropertyElementsVM()
        {
            ObjectPropperties = new ObservableCollection<PropertyObj>();
        }

        public ICommand Delete
        {
            get
            {
                return new ParamCommand(item =>
                {
                    if (item != null)
                    {
                        try
                        {
                            var DeletedItem = item as PropertyObj;
                            AppService.StaticStoredObjs.Remove(DeletedItem);
                            AppService.StaticStoredObjs.SaveChanges();
                            ObjectPropperties.Remove(DeletedItem);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно удалить. \nВозможно объект используется.", "Предупреждение",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                });
            }
        }


        public ICommand Create
        {
            get
            {
                return new ParamCommand(index =>
                {
                    CreateByListItem((int)index);
                });
            }
        }

        private void CreateByListItem(int index)
        {
            var creatDialog = new CreatePropertyDialog();
            var Vm = creatDialog.DataContext as CreatePropertyDialogVM;

            switch (index)
            {
                case 0:
                    {
                        if(creatDialog.ShowDialog() == true)
                        {
                            var newLitera = new Litera() { Name = Vm.Name, dbImage = AppService.ConverBitmapImageToByteArray(Vm.PropImage) };
                            newLitera.Save();
                            ObjectPropperties.Add(newLitera);
                        }
                        break;
                    }
                case 1:
                    {
                        if (creatDialog.ShowDialog() == true)
                        {
                            var newClass = new ProdactClass() { Name = Vm.Name, dbImage = AppService.ConverBitmapImageToByteArray(Vm.PropImage) };
                            newClass.Save();
                            ObjectPropperties.Add(newClass);
                        }
                        break;
                    }
                case 2:
                    {
                        if (creatDialog.ShowDialog() == true)
                        {
                            var newLC = new LifeCycleState() { Name = Vm.Name, dbImage = AppService.ConverBitmapImageToByteArray(Vm.PropImage) };
                            newLC.Save();
                            ObjectPropperties.Add(newLC);
                        }
                        break;
                    }
            }

            AppService.PropertyVM.UpdateProperties();
        }

        public ICommand GetItem
        {
            get
            {
                return new ParamCommand(index =>
                {
                    LoadDataByListItem((int)index);
                });
            }
        }

        private void LoadDataByListItem(int index)
        {
            ObjectPropperties.Clear();

            switch (index)
            {
                case 0:
                    {
                        AppService.StaticStoredObjs.Literas.ToList().ForEach(e=>ObjectPropperties.Add(e));
                        break;
                    }
                case 1:
                    {
                        AppService.StaticStoredObjs.ProdactClasses.ToList().ForEach(e => ObjectPropperties.Add(e));
                        break;
                    }
                case 2:
                    {
                        AppService.StaticStoredObjs.LifeCycleStates.ToList().ForEach(e => ObjectPropperties.Add(e));
                        break;
                    }
            }
        }
    }
}
