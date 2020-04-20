using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows.Media.Imaging;

namespace MvvmProdactApp.Models.ObjProppsClasses
{
    public abstract class PropertyObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
        public byte[] dbImage { get; set; }
        [NotMapped]
        public BitmapImage Image { get { return AppService.ConvertBitmap(dbImage);  } }
        
        public virtual void Save() { }
    }
}
