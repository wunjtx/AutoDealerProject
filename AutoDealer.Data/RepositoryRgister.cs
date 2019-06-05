using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDealer.Core.Data;
using AutoDealer.Core.Infrastucture;
using Unity;

namespace AutoDealer.Data
{
    public class RepositoryRgister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDbContext, AutoDbContext>();
            container.RegisterType(typeof(IRepository<>),typeof(EfRepository<>));
        }
    }
}
