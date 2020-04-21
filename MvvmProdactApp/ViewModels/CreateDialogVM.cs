using MvvmProdactApp.Models;
using MvvmProdactApp.Models.ObjProppsClasses;
using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MvvmProdactApp.ViewModels
{
    public class CreateDialogVM : NotifyInterface
    {
        private string name;
        private string designation;
        private Visibility fieldVisible;
        private string selectedType;
        private Litera newLitera;
        private ProdactClass newProdactClass;
        private LifeCycleState newLifeCycleState;
        private ECNsection newSection;

        public ObservableCollection<string> Typies { get; set; }

        public ObservableCollection<Litera> Literas { get; set; }
        public ObservableCollection<ProdactClass> ProdactClasses { get; set; }
        public ObservableCollection<LifeCycleState> LifeCycleStates { get; set; }
        public ObservableCollection<ECNsection> ECNsections { get; set; }
        public CreateDialogVM()
        {
            Typies = new ObservableCollection<string>() { "DataContainer", "ProdactObject" };

            Literas = new ObservableCollection<Litera>();
            AppService.StaticStoredObjs.Literas.ToList().ForEach(e => Literas.Add(e));

            ProdactClasses = new ObservableCollection<ProdactClass>();
            AppService.StaticStoredObjs.ProdactClasses.ToList().ForEach(e => ProdactClasses.Add(e));

            ECNsections = new ObservableCollection<ECNsection>();
            AppService.StaticStoredObjs.ECNsections.ToList().ForEach(e => ECNsections.Add(e));

            LifeCycleStates = new ObservableCollection<LifeCycleState>();
            AppService.StaticStoredObjs.LifeCycleStates.ToList().ForEach(e => LifeCycleStates.Add(e));
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChangedEvent("Name");
            }
        }
        public string Designation
        {
            get { return designation; }
            set
            {
                designation = value;
                RaisePropertyChangedEvent("Designation");
            }
        }
        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                RaisePropertyChangedEvent("SelectedType");
            }
        }

        public Litera NewLitera
        {
            get { return newLitera; }
            set
            {
                newLitera = value;
                RaisePropertyChangedEvent("NewLitera");
            }
        }
        public ProdactClass NewProdactClass
        {
            get { return newProdactClass; }
            set
            {
                newProdactClass = value;
                RaisePropertyChangedEvent("NewProdactClass");
            }
        }
        public LifeCycleState NewLifeCycleState
        {
            get { return newLifeCycleState; }
            set
            {
                newLifeCycleState = value;
                RaisePropertyChangedEvent("NewLifeCycleState");
            }
        }
        public ECNsection NewSection
        {
            get { return newSection; }
            set
            {
                newSection = value;
                RaisePropertyChangedEvent("NewSection");
            }
        }

        public Visibility FieldVisible
        {
            get { return fieldVisible; }
            set
            {
                fieldVisible = value;
                RaisePropertyChangedEvent("FieldVisible");
            }
        }

        public ICommand TypeSelection
        {
            get
            {
                return new ParamCommand(type => ChangeFieldVisible((string)type));
            }
        }

        private void ChangeFieldVisible(string type)
        {
            FieldVisible = Visibility.Visible;
            if (type == "DataContainer")
                FieldVisible = Visibility.Hidden;
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

        public HierarchicalObject GetResultObject()
        {
            if (Name == null)
                return null;

            HierarchicalObject newObject;
            if(SelectedType.Equals("DataContainer"))
            {
                newObject = new DataContainer()
                {
                    Name = Name
                };
            }
            else
            {
                newObject = new ProdactObject()
                { 
                    Name = Name,
                    Props = new ObjProperties()
                    { 
                        Designation = Designation,
                        Litera = NewLitera,
                        Class = NewProdactClass,
                        LCstate = NewLifeCycleState,
                        Section = NewSection
                    }
                };
            }

            return newObject;
        }
    }
}
