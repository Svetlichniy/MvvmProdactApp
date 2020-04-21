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
        public override string NameUI { get { return Name; } }
        [NotMapped]
        public List<DataContainer> ChildCons { get { return GetChildCons(); } }
        public virtual ObservableCollection<HierarchicalObject> Prodacts { get; set; }

        public DataContainer()
        {
            Prodacts = new ObservableCollection<HierarchicalObject>();
            Image = AppService.ConvertBitmap(Resource1.folder);
        }

        public override void Save()
        {
            if (AppService.StaticStoredObjs.DataContainers.Find(Id) == null)
                AppService.StaticStoredObjs.DataContainers.Add(this);
            else
                AppService.StaticStoredObjs.DataContainers.Update(this);
            AppService.StaticStoredObjs.SaveChanges();
        }

        public override void Remove()
        {
            foreach(var prod in Prodacts)
            {
                prod.Remove(true);
            }

            AppService.StaticStoredObjs.Remove(this);
            AppService.StaticStoredObjs.SaveChanges();
        }

        public override void Remove(bool WaitSave)
        {
            foreach (var prod in Prodacts)
            {
                prod.Remove(true);
            }

            AppService.StaticStoredObjs.Remove(this);
        }

        private List<DataContainer> GetChildCons()
        {
            var ChildConsList = new List<DataContainer>();

            return ChildConsList;
        }
    }
}
