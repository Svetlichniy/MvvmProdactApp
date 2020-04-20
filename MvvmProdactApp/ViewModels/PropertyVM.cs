using MvvmProdactApp.Models;
using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MvvmProdactApp.ViewModels
{
    public class PropertyVM : NotifyInterface
    {
        private ProdactObject selectedItem;
        private Visibility propsVisible;

        public ProdactObject SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChangedEvent("SelectedItem");
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

        public PropertyVM()
        {
            AppService.PropertyVM = this;
        }
    }
}
