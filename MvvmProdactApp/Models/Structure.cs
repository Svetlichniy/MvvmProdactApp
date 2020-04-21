using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvvmProdactApp.Models
{
    public class ObjStructure
    {
        public int Id { get; set; }
        public int Position { get; set; }

        public virtual LinkToObject LinkToObj { get; set; }

        public int Count { get; set; }
        public string Annotation { get; set; }

        public ObjStructure()
        {

        }
    }
}