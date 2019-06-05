using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AutoDealer.Core.Infrastucture
{
    public static class ServiceContainer
    {
        static Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(()=>new UnityContainer());

        public static IUnityContainer Current { get { return Container.Value; } }

        public static T Resolve<T>() where T : class
        {
            return Container.Value.Resolve<T>();
        }

        public static IEnumerable<T> ResolveAll<T>() where T : class
        {
            return Container.Value.ResolveAll<T>(); 
        }
    }
}
