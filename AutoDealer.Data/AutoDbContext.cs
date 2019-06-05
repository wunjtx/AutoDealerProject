using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using AutoDealer.Data.Mapping;

namespace AutoDealer.Data
{
    public class AutoDbContext : DbContext, IDbContext
    {
        static AutoDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AutoDbContext>());
        }

        public AutoDbContext():base("AutoDb")
        {

        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
           return this.Database.ExecuteSqlCommand(sql,parameters);
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AutoMap());
            modelBuilder.Configurations.Add(new BrandMap());
            modelBuilder.Configurations.Add(new MakerMap());
            modelBuilder.Configurations.Add(new ImgMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
