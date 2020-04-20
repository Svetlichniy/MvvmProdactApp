using MvvmProdactApp.Services;

namespace MvvmProdactApp.Models.ObjProppsClasses
{
    public class ProdactClass : PropertyObj
    {
        public override void Save()
        {
            if (AppService.StaticStoredObjs.ProdactClasses.Find(Id) == null)
                AppService.StaticStoredObjs.ProdactClasses.Add(this);
            else
                AppService.StaticStoredObjs.ProdactClasses.Update(this);
            AppService.StaticStoredObjs.SaveChanges();
        }

    }
}