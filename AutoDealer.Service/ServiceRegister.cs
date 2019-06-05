using AutoDealer.Core.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDealer.Service;
using Unity;

namespace CarManager.Service
{
    public class ServiceRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAutoService, AutoService>();
        }
    }
}
