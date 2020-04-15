using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmProdactApp.Models
{
    public abstract class HierarchicalObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
    }
}
