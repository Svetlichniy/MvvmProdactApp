using System.Windows.Media.Imaging;
using System.ComponentModel.DataAnnotations.Schema;
using MvvmProdactApp.Services;

namespace MvvmProdactApp.Models.ObjProppsClasses
{
    public class LifeCycleState : PropertyObj
    {

        public override void Save()
        {
            if (AppService.StaticStoredObjs.LifeCycleStates.Find(Id) == null)
                AppService.StaticStoredObjs.LifeCycleStates.Add(this);
            else
                AppService.StaticStoredObjs.LifeCycleStates.Update(this);
            AppService.StaticStoredObjs.SaveChanges();
        }

    }
}