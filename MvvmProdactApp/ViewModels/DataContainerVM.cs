using MvvmProdactApp.Models;
using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmProdactApp.ViewModels
{
    public class DataContainerVM : NotifyInterface
    {
        private DataContainer selectedContainer;

        public DataContainerVM()
        {
            AppService.DataContainerVM = this;
        }

        public DataContainer SelectedContainer
        {
            get { return selectedContainer; }
            set
            {
                selectedContainer = value;
                RaisePropertyChangedEvent("SelectedContainer");
            }
        }
    }
}
