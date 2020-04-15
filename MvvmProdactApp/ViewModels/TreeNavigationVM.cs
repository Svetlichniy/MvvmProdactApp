using MvvmProdactApp.DataContext;
using MvvmProdactApp.Models;
using MvvmProdactApp.Services;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MvvmProdactApp.ViewModels
{
    public class TreeNavigationVM : NotifyInterface
    {
        public ObservableCollection<HierarchicalObject> Items { get; set; }
        public StoredObjects StoredObjs { get; set; }
        public TreeNavigationVM()
        {
            Items = new ObservableCollection<HierarchicalObject>();
            StoredObjs = new StoredObjects();
            //InitObjects();
            StartUp();
        }


        public ICommand Create
        {
            get
            {
                return new ParamCommand(obj =>
                {
                    var SelectedItem = obj as HierarchicalObject;
                    if (SelectedItem.Discriminator.Equals("DataContainer"))
                    {
                        var dc = SelectedItem as DataContainer;
                        dc.Prodacts.Add(new DataContainer() { Name = "EEEEE"+new Random().Next(1, 5467) });
                        StoredObjs.Update(dc);
                        StoredObjs.SaveChanges();
                    }
                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new ParamCommand(obj =>
                {
                    var SelectedItem = obj as HierarchicalObject;
                    StoredObjs.Remove(SelectedItem);
                    StoredObjs.SaveChanges();
                });
            }
        }

        public ICommand GetItem 
        {
            get 
            {
                return new ParamCommand(obj => 
                {
                    MessageBox.Show(obj.ToString()) ;
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
