using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MvvmProdactApp.Models
{
    public abstract class HierarchicalObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public virtual string NameUI { get; }
        public string Discriminator { get; set; }

        public virtual void Save() { }
        public virtual void Remove() { }
        public virtual void Remove(bool WaitSave) { }
    }
}
