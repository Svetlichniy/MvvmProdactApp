using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmProdactApp.ViewModels
{
    public class ProdactVM : NotifyInterface
    {
        private int switchView;

        public ProdactVM()
        {
            AppService.ProdactVM = this;
            SwitchView = 0;
        }

        public int SwitchView
        {
            get { return switchView; }
            set
            {
                switchView = value;
                RaisePropertyChangedEvent("SwitchView");
            }
        }
    }
}
