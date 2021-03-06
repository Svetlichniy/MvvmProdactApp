﻿using MvvmProdactApp.DataContext;
using MvvmProdactApp.Models;
using MvvmProdactApp.Services;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MvvmProdactApp.Views;

namespace MvvmProdactApp.ViewModels
{
    public class TreeNavigationVM : NotifyInterface
    {
        public ObservableCollection<HierarchicalObject> Items { get; set; }
        public StoredObjects StoredObjs { get; set; }
        public HierarchicalObject SelectedTreeItem { get; set; }
        public TreeNavigationVM()
        {
            Items = new ObservableCollection<HierarchicalObject>();
            StoredObjs = new StoredObjects();
            AppService.StaticStoredObjs = StoredObjs;
            AppService.TreeNavigationVM = this;
            //InitObjects();
            StartUp();
        }


        public ICommand Create
        {
            get
            {
                return new ParamCommand(selectedCon =>
                {
                    CreateObj(selectedCon);
                });
            }
        }

        private void CreateObj(object obj)
        {
            var SelectedItem = obj as HierarchicalObject;
            if (SelectedItem.Discriminator.Equals("DataContainer"))
            {
                var SelectedContainer = SelectedItem as DataContainer;
                var creatDialog = new CreateDialog();
                var Vm = creatDialog.DataContext as CreateDialogVM;
                if (creatDialog.ShowDialog() == true)
                {
                    var newItem = Vm.GetResultObject();
                    if (newItem != null)
                    {
                        SelectedContainer.Prodacts.Add(newItem);
                        SelectedContainer.Save();
                    }
                }
            }
        }

        public ICommand Delete
        {
            get
            {
                return new ParamCommand(obj =>
                {
                    var SelectedItem = obj as HierarchicalObject;
                    SelectedItem.Remove();
                });
            }
        }

        public ICommand GetItem 
        {
            get 
            {
                return new ParamCommand(obj => 
                {
                    SelectedTreeItem = obj as HierarchicalObject;
                    if (SelectedTreeItem.Discriminator.Equals("ProdactObject"))
                    {
                        AppService.ProdactVM.SwitchView = 1;
                        AppService.PropertyVM.SelectedItem = SelectedTreeItem as ProdactObject;
                    }
                    else
                    {
                        AppService.ProdactVM.SwitchView = 0;
                        AppService.DataContainerVM.SelectedContainer = SelectedTreeItem as DataContainer;
                    }
                });
            }
        }


        private void StartUp()
        {
            var Root = StoredObjs.DataContainers.ToList().First();

            Items.Add(Root);
        }
        private void InitObjects()
        {
            var Root = new DataContainer() { Name = "Root" };
            var Prodact = new ProdactObject() { Name = "Lvl1" };
            Prodact.Props = new ObjProperties() { Designation = "465456456400" };
            Root.Prodacts.Add(Prodact);
            Items.Add(Root);

            StoredObjs.DataContainers.Add(Root);
            StoredObjs.SaveChanges();
        }
    }
}
