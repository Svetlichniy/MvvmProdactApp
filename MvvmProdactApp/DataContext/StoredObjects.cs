using Microsoft.EntityFrameworkCore;
using MvvmProdactApp.Models;
using MvvmProdactApp.Models.ObjProppsClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MvvmProdactApp.DataContext
{
    public class StoredObjects : DbContext
    {
        public DbSet<HierarchicalObject> HierarchicalObjects { get; set; }
        public DbSet<DataContainer> DataContainers { get; set; }
        public DbSet<ProdactObject> ProdactObjects { get; set; }
        public DbSet<ObjStructure> ObjStructures { get; set; }
        public DbSet<PropertyObj> _AbstractPropertyObjs { get; set; }
        public DbSet<Litera> Literas { get; set; }
        public DbSet<ProdactClass> ProdactClasses { get; set; }
        public DbSet<LifeCycleState> LifeCycleStates { get; set; }
        public DbSet<ECNsection> ECNsections { get; set; }
        public DbSet<ObjProperties> ObjProperties { get; set; }


        public StoredObjects()
        {
            
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=Relationsdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
