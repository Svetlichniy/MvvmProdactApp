using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Resources;
using System.Text;
using System.Windows.Media.Imaging;

namespace MvvmProdactApp.Models
{
    public class DataContainer : HierarchicalObject
    {
        [NotMapped]
        public BitmapImage Image { get; set; }
        public virtual ObservableCollection<HierarchicalObject> Prodacts { get; set; }

        public DataContainer()
        {
            Prodacts = new ObservableCollection<HierarchicalObject>();
            Image = AppService.ConvertBitmap(Resource1.folder);
        }
    }
}
