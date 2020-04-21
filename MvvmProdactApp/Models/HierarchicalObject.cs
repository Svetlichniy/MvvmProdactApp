using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows.Media.Imaging;

namespace MvvmProdactApp.Models
{
    public abstract class HierarchicalObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public virtual string NameUI { get; }
        [NotMapped]
        public BitmapImage Image { get; set; }

        public string Discriminator { get; set; }

        public virtual void Save() { }
        public virtual void Remove() { }
        public virtual void Remove(bool WaitSave) { }
    }
}
