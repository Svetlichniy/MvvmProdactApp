using MvvmProdactApp.Services;
using System.Linq;

namespace MvvmProdactApp.Models.ObjProppsClasses
{
    public class Litera : PropertyObj
    {

        public override void Save()
        {
            if (AppService.StaticStoredObjs.Literas.Find(Id) == null)
                AppService.StaticStoredObjs.Literas.Add(this);
            else
                AppService.StaticStoredObjs.Literas.Update(this);
            AppService.StaticStoredObjs.SaveChanges();
        }
    }
}