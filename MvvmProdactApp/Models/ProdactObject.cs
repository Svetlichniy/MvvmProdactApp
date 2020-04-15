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
        public virtual ObjProperties Props { get; set; }
        public virtual List<ObjStructure> Structure { get; set; }

        public ProdactObject()
        {
            Image = AppService.ConvertBitmap(Resource1.other);
        }
    }
}
