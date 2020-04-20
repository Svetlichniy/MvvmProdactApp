using MvvmProdactApp.Models.ObjProppsClasses;

namespace MvvmProdactApp.Models
{
    public class ObjProperties
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public virtual Litera Litera { get; set; }
        public virtual ProdactClass Class { get; set; }
        public virtual LifeCycleState LCstate { get; set; }
    }
}