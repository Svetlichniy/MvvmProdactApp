using MvvmProdactApp.Models;
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
    public class PropertyVM : NotifyInterface
    {
        private ProdactObject selectedItem;
        private Visibility propsVisible;

        public ObservableCollection<string> Typies { get; set; }

        public ObservableCollection<Litera> Literas { get; set; }
        public ObservableCollection<ProdactClass> ProdactClasses { get; set; }
        public ObservableCollection<ECNsection> ECNsections { get; set; }
        public ObservableCollection<LifeCycleState> LifeCycleStates { get; set; }

        public ObservableCollection<ProdactObject> Occurrences { get; set; }

        public ProdactObject SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChangedEvent("SelectedItem");
                GetOccurrences(selectedItem);
            }
        }
        public Visibility PropsVisible
        {
            get { return propsVisible; }
            set
            {
                propsVisible = value;
                RaisePropertyChangedEvent("PropsVisible");
            }
        }

        public ICommand Save
        {
            get { return new ParamCommand(obj =>
            {
                SelectedItem.Save();
            }); }
        }

        public ICommand AddStructure
        {
            get { return new ParamCommand(obj => AddNewStructure()); }
        }

        private void AddNewStructure()
        {
            var AddStructureDialog = new AddNewStructureDialog();
            var Vm = AddStructureDialog.DataContext as AddNewStructureVM;

            if(AddStructureDialog.ShowDialog() == true)
            {
                var NewItems = Vm.SelectedProdacts.ToList();
                foreach (var item in NewItems)
                    SelectedItem.Structure.Add(new ObjStructure()
                    {
                        LinkToObj = new LinkToObject() { ProdactObj = item },
                        Position = 0,
                        Count = 0
                    });

                SelectedItem.Save();
            }
        }

        public ICommand RemoveStructure
        {
            get { return new ParamCommand(obj => _RemoveStructure(obj)); }
        }

        private void _RemoveStructure(object obj)
        {
            var selectedItem = obj as ObjStructure;
            SelectedItem.Structure.Remove(selectedItem);
            SelectedItem.Save();

            AppService.StaticStoredObjs.Remove(selectedItem);
            AppService.StaticStoredObjs.Remove(selectedItem.LinkToObj);
            AppService.StaticStoredObjs.SaveChanges();
        }


        public PropertyVM()
        {
            AppService.PropertyVM = this;

            Typies = new ObservableCollection<string>() { "DataContainer", "ProdactObject" };
            UpdateProperties();

        }

        public void UpdateProperties()
        {
            Literas = new ObservableCollection<Litera>();
            AppService.StaticStoredObjs.Literas.ToList().ForEach(e => Literas.Add(e));

            ProdactClasses = new ObservableCollection<ProdactClass>();
            AppService.StaticStoredObjs.ProdactClasses.ToList().ForEach(e => ProdactClasses.Add(e));

            LifeCycleStates = new ObservableCollection<LifeCycleState>();
            AppService.StaticStoredObjs.LifeCycleStates.ToList().ForEach(e => LifeCycleStates.Add(e));

            ECNsections = new ObservableCollection<ECNsection>();
            AppService.StaticStoredObjs.ECNsections.ToList().ForEach(e => ECNsections.Add(e));

            Occurrences = new ObservableCollection<ProdactObject>();
        }

        private void GetOccurrences(ProdactObject selectedItem)
        {
            Occurrences.Clear();
            var Structures = AppService.StaticStoredObjs.ObjStructures.ToList().Where(e => e.LinkToObj.ProdactObj == selectedItem);
            foreach (var str in Structures)
                Occurrences.Add(str.ProdactObject);
        }
    }
}
