using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows.Media.Imaging;

namespace MvvmProdactApp.Models
{
    public class ProdactObject : HierarchicalObject
    {
        [NotMapped]
        public BitmapImage Image { get; set; }
        [NotMapped]
        public override string NameUI { get { return Props.Designation + " " + Name; } }

        public virtual ObjProperties Props { get; set; }
        public virtual List<ObjStructure> Structure { get; set; }

        public ProdactObject()
        {
            Image = AppService.ConvertBitmap(Resource1.other);
        }

        public override void Save()
        {
            if (AppService.StaticStoredObjs.ProdactObjects.Find(Id) == null)
                AppService.StaticStoredObjs.ProdactObjects.Add(this);
            else
                AppService.StaticStoredObjs.ProdactObjects.Update(this);
            AppService.StaticStoredObjs.SaveChanges();
        }

        public override void Remove()
        {
            AppService.StaticStoredObjs.Remove(this);
            if(Props != null)
                AppService.StaticStoredObjs.Remove(Props);

            AppService.StaticStoredObjs.SaveChanges();
        }

        public override void Remove(bool WaitSave)
        {
            AppService.StaticStoredObjs.Remove(this);
            if (Props != null)
                AppService.StaticStoredObjs.Remove(Props);
        }
    }
}
