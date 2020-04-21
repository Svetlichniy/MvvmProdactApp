namespace MvvmProdactApp.Models
{
    public class LinkToObject
    {
        public int Id { get; set; }
        public virtual ProdactObject ProdactObj { get; set; }
    }
}