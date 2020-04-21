using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmProdactApp.Models.ObjProppsClasses
{
    public class ECNsection : PropertyObj
    {
        public override void Save()
        {
            if (AppService.StaticStoredObjs.ECNsections.Find(Id) == null)
                AppService.StaticStoredObjs.ECNsections.Add(this);
            else
                AppService.StaticStoredObjs.Update(this);
            AppService.StaticStoredObjs.SaveChanges();
        }
    }
}
