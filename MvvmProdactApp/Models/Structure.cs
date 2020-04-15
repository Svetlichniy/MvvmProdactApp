namespace MvvmProdactApp.Models
{
    public class ObjStructure
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public virtual ProdactObject prodactObject { get; set; }
        public int Count { get; set; }
        public string Annotation { get; set; }
    }
}